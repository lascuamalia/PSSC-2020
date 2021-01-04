using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner
{
   public class SendAcknowledgementToQuestionOwnerCmd
    {
        public SendAcknowledgementToQuestionOwnerCmd(int questionId, int questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }
        public int QuestionId { get; }
        public int QuestionOwnerId { get; }
    }
}
