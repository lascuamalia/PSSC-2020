using Access.Primitives.EFCore;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CreateReplyOp;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.SendReplyAuthorAcknowledgementOp;
using StackUnderflow.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questionsreply")]
    public class QuestionsReplyController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly DatabaseContext _dbContext;

        public QuestionsReplyController(IInterpreterAsync interpreter, DatabaseContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("createReply")]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyCmd cmd)
        {
            var dep = new QuestionsDependencies();

            var replies = await _dbContext.Replies.ToListAsync();
            _dbContext.Replies.AttachRange(replies);

            var ctx = new QuestionsWriteContext(new EFList<Reply>(_dbContext.Replies));

            var expr = from createTenantResult in QuestionsContextOp.CreateReply(cmd)
                           //let checkLanguageCmd = new CheckLanguageCmd()
                       from checkLanguageResult in QuestionsContextOp.CheckLanguage(new CheckLanguageOpCmd(cmd.Body))
                       from sendAckAuthor in QuestionsContextOp.SendReplyAuthorAcknowledgement(new SendReplyAuthorAcknowledgementCmd(Guid.NewGuid(), 1, 2))
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            //_dbContext.Replies.Add(new DatabaseModel.Models.Reply { Body = cmd.Body, AuthorUserId = 1, QuestionId = cmd.QuestionId, ReplyId = 4 });
            //var reply = await _dbContext.Replies.Where(r => r.ReplyId == 4).SingleOrDefaultAsync();
            //reply.Body = "Text updated";
            //_dbContext.Replies.Update(reply);
            await _dbContext.SaveChangesAsync();


            return r.Match(
                succ => (IActionResult)Ok(succ.Body),
                fail => BadRequest("Reply could not be added")
                );
        }
    }
}
