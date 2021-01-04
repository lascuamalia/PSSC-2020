using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class TextChecked : ICheckLanguageResult
        {
            public string Verified { get; }
            public TextChecked(string verified)
            {
                Verified = verified;
            }
        }
        public class TextNotCheck : ICheckLanguageResult
        {
            public string ErrorMessage { get; }
            public TextNotCheck(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
        public class ManualReviewRequired : ICheckLanguageResult
        {
            public string Text { get; }
            public ManualReviewRequired(string text)
            {
                Text = text;
            }
        }
    }
}