using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Adapters.SendReplyAuthorAcknowledgement
{
    public partial class SendReplyAuthorAcknowledgementAdaptor : Adapter<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult, QuestionsReadContext>
    {
        public override Task PostConditions(SendReplyAuthorAcknowledgementCmd cmd, ISendReplyAuthorAcknowledgementResult result, QuestionsReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ISendReplyAuthorAcknowledgementResult> Work(SendReplyAuthorAcknowledgementCmd cmd, QuestionsReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;
            return await result.Match(

                Succ: valid => new AcknowledgementSent(1,cmd.QuestionId,cmd.Reply),
                Fail: ex => new AcknowledgementSent(1, cmd.QuestionId, cmd.Reply));
        }
    }
}
