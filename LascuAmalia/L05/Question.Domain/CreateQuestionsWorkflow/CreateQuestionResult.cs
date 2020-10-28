using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateQuestionsWorkflow
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {

        public interface ICreateQuestionResult { }

        public class QuestionPosted:ICreateQuestionResult
        {
            public string Text { get; private set; }
            public int VoteCount { get; private set; }
            public string[] Tags { get; private set; }
            public QuestionPosted(string text, int voteCount, string[] tags)
            {
                Text = text;
                VoteCount = voteCount;
                Tags = tags;

            }

         
        }

        public class QuestionNoPosted:ICreateQuestionResult
        {
            public string Reason { get; set; }
            public QuestionNoPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class InvalidQuestion:ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public InvalidQuestion(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
