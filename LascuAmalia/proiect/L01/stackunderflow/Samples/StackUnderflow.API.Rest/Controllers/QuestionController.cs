using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionCmd cmd)
        {
            var dep = new QuestionDependencies();
            var ctx = new QuestionWriteContext();

            var expr = from createTenantResult in QuestionContext.CreateQuestion(cmd)
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
