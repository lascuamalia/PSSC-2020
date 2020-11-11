using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;

namespace StackUnderflow.Adapters.CreateReply
{
    public partial class CreateReplyAdaptor : Adapter<CreateReplyCmd, ICreateReplyResult, QuestionReadContext>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionReadContext state)
        {
            throw new NotImplementedException();
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionReadContext state)
        {
            var result = from validate in cmd.TryValidate()
                         select validate;
            return await result.Match(

                Succ: valid => new ReplyCreated(1, cmd.QuestionId, cmd.AuthorUserId, cmd.Body),
                Fail: ex => new ReplyCreated(1, cmd.QuestionId, cmd.AuthorUserId, cmd.Body));
        }
    }
}
