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
            var replies = await _dbContext.Questions.ToListAsync();
            _dbContext.Questions.AttachRange(replies);

            var ctx = new QuestionsWriteContextC(new EFList<Question>(_dbContext.Questions));

            var expr = from createTenantResult in QuestionContext.CreateQuestion(cmd)
                       from checkLanguageResult in QuestionContext.CheckLanguage(new CheckLanguageCmd(cmd.Text))
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            return r.Match(
                created => Ok(created),
                notCreated => BadRequest(notCreated),
                invalidRequest => ValidationProblem()
                );
        }
    }
}
