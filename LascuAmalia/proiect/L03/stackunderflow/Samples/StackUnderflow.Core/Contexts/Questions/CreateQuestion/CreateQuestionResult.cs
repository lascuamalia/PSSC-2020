using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {

        public interface ICreateQuestionResult { }

        public class QuestionPosted : ICreateQuestionResult
        {
           
            public QuestionPosted(Guid questionId,string titlu,string text, string tags)
            {
                QuestionId = questionId;
                Titlu = titlu;
                Text = text;
                Tags = tags;

            }
            public Guid QuestionId { get; set; }
            public string Titlu { get; set; }
            public string Text { get; set; }
            public string Tags { get; set; }


        }

        public class QuestionNoPosted : ICreateQuestionResult
        {
            public QuestionNoPosted(string reason)
            {
                Reason = reason;
            }
            public string Reason { get; set; }
        }

        public class InvalidQuestion : ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public InvalidQuestion(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
