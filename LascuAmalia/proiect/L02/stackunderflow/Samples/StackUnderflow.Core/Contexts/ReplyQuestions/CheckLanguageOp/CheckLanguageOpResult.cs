using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp
{
    [AsChoice]
    public static partial class CheckLanguageOpResult
    {
        public interface ICheckLanguageOpResult { }

        public class ValidationSucceeded : ICheckLanguageOpResult
        {
            public ValidationSucceeded(string text)
            {
                Text = text;
            }

            public string Text { get; set; }
        }

        public class ValdidationFaild : ICheckLanguageOpResult
        {
            public ValdidationFaild(string message)
            {
                Message = message;
            }

            public string Message { get; set; }
        }

        public class ManualReviewRequired : ICheckLanguageOpResult
        {
            public ManualReviewRequired(string text)
            {
                Text = text;
            }

            public string Text { get; set; }
        }
    }
}
