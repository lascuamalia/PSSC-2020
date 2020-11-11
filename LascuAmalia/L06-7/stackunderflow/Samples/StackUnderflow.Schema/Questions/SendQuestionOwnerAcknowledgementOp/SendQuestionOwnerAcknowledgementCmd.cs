using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp
{
    public class SendQuestionOwnerAcknowledgementCmd
    {
        public SendQuestionOwnerAcknowledgementCmd(int questionId, Guid questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }

        public int QuestionId { get; }
        public Guid QuestionOwnerId { get; }
    }
}
