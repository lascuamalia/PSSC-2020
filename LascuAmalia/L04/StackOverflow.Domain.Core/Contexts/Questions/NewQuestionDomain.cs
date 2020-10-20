using Primitives.IO;
using StackOverflow.Domain.Schema.Questions.AskQuestionOp;
using System;
using System.Collections.Generic;
using System.Text;
using static StackOverflow.Domain.Schema.Questions.AskQuestionOp.AskQuestionResult;

namespace StackOverflow.Domain.Core.Contexts.Questions
{
   public  class NewQuestionDomain
    {
        public static Port<IAskQuestionResult>Published(string question) => NewPort <AskQuestionCmd, IAskQuestionResult> (new AskQuestionCmd(question));
    }
}
