using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion.CreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult, QuestionsWriteContextC, QuestionsDependenciesC>
    {
        public override Task PostConditions(CreateQuestionCmd cmd, CreateQuestionResult.ICreateQuestionResult result, QuestionsWriteContextC state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICreateQuestionResult> Work(CreateQuestionCmd cmd, QuestionsWriteContextC state, QuestionsDependenciesC dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddQuestion(state, CreateQuestionFromCmd(cmd))
                           select t;
            //aici se introduc datele, state-ul este QuestionWrite Contextul meu
            
            state.Questions.Add(new DatabaseModel.Models.Question { QuestionId = Guid.NewGuid(), Titlu = "Titlul pentru intrebare", Text = "Textul intrebarii", Tags = "Tag-uri pentru intrebare" });
            var result = await workflow.Match(
                Succ: r => r,
                Fail: er => new QuestionNoPosted(er.Message)
                );

            return result;
        }

        public ICreateQuestionResult AddQuestion(QuestionsWriteContextC state, object v)
        {
            return new QuestionPosted(Guid.NewGuid(), "Tilu","Text intrebarii", "Tags");
        }

        private object CreateQuestionFromCmd(CreateQuestionCmd cmd)
        {
            return new { };
        }
    }
}
