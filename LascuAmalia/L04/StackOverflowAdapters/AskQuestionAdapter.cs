using Primitives.IO;
using StackOverflow.Domain.Schema.Questions.AskQuestionOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackOverflow.Domain.Schema.Questions.AskQuestionOp.AskQuestionResult;

namespace StackOverflowAdapters
{
    public class AskQuestionAdapter : Adapter<AskQuestionCmd, IAskQuestionResult>
    {
        public override Task PostConditions(AskQuestionCmd cmd, IAskQuestionResult result, object state)
        {
            throw new NotImplementedException();
        }

        public override async Task<IAskQuestionResult> Work(AskQuestionCmd cmd, object state)
        {
            return new Published();
        }
    }
}
