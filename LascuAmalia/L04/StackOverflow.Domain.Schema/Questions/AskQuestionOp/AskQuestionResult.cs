using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.AskQuestionOp
{
    [AsChoice]
   public static partial class AskQuestionResult
    {
        public interface IAskQuestionResult { }

        public class Published : IAskQuestionResult
        {

        }

        public class NotPublished : IAskQuestionResult { }
    }
}
