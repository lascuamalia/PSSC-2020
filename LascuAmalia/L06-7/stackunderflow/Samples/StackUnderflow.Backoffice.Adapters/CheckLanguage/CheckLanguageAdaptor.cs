using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Schema.Questions.CheckLanguageOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;

namespace StackUnderflow.Adapters.CheckLanguage
{
    public partial class CheckLanguageAdaptor : Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionReadContext>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;
            return await result.Match(

                Succ: valid => new ValidationSucceeded(cmd.Text),
                Fail: ex => new ValidationSucceeded(cmd.Text));
        }
    }
}
