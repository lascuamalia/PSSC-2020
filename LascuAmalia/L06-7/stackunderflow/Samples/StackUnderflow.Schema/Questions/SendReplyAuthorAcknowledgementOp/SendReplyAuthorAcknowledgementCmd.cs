using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;

namespace StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp
{
    public class SendReplyAuthorAcknowledgementCmd
    {
        public SendReplyAuthorAcknowledgementCmd(Guid replyAuthorId, int questionId, Option<ReplyCreated> reply)
        {
            ReplyAuthorId = replyAuthorId;
            QuestionId = questionId;
            Reply = Reply;
        }

        public Guid ReplyAuthorId { get; }
        public int QuestionId { get; }
        public ReplyCreated Reply { get; }
    }
}
