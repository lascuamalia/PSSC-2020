using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.EF.Models;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions;
using StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly DatabaseContextC _dbContext;

        public QuestionController(IInterpreterAsync interpreter, DatabaseContextC dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd cmd)
        {
            var dep = new QuestionsDependencies();
            var questions = await _dbContext.Questions.ToListAsync();
            _dbContext.Questions.AttachRange(questions);

            var ctx = new QuestionsWriteContextC(new EFList<Question>(_dbContext.Questions));

            var expr = from createQuestionResult in QuestionContext.CreateQuestion(cmd)
                       from checkLanguageResult in QuestionContext.CheckLanguage(new CheckLanguageCmd(cmd.Text))
                       from sendAckOwner in QuestionContext.SendAcknowledgementToQuestionOwner(new SendAcknowledgementToQuestionOwnerCmd(1, 2))
                       select createQuestionResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);
            _dbContext.Questions.Add(new DatabaseModel.Models.Question { QuestionId = Guid.NewGuid(), Titlu = cmd.Titlu, Text = cmd.Text, Tags = cmd.Tags });
            await _dbContext.SaveChangesAsync();

            return r.Match(
                succ => (IActionResult)Ok(succ.Text),
                notCreated => BadRequest("NotPosted"),
                invalidRequest => ValidationProblem()
                );
        }
    }
}
