using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp.CheckLanguageOpResult;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp
{
   public class CheckLanguageAdaptor : Adapter<CheckLanguageCmd, ICheckLanguageOpResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageOpResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICheckLanguageOpResult> Work(CheckLanguageCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            return  new ValidationSucceeded("Valid");
        }
    }
}
