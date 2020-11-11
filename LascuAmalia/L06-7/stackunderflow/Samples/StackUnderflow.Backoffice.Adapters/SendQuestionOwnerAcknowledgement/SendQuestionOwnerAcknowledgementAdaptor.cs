using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;

namespace StackUnderflow.Adapters.SendQuestionOwnerAcknowledgement
{
    public partial class SendQuestionOwnerAcknowledgementAdaptor : Adapter<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult, QuestionsReadContext>
    {
        public override Task PostConditions(SendQuestionOwnerAcknowledgementCmd cmd, ISendQuestionOwnerAcknowledgementResult result, QuestionsReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ISendQuestionOwnerAcknowledgementResult> Work(SendQuestionOwnerAcknowledgementCmd cmd, QuestionsReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;
            return await result.Match(

                Succ: valid => new AcknowledgementSent(cmd.QuestionId,cmd.QuestionOwnerId),
                Fail: ex => new AcknowledgementSent(cmd.QuestionId, cmd.QuestionOwnerId));
        }
    }
}
