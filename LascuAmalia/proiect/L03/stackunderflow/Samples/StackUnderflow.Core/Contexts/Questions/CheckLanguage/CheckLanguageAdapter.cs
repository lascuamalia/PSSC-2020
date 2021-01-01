using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage.CheckLanguageResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage
{
    class CheckLanguageAdapter:Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionsWriteContextC, QuestionsDependenciesC>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionsWriteContextC state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionsWriteContextC state, QuestionsDependenciesC dependencies)
        {
            return new TextChecked("TextValid");
        }
    }
}
