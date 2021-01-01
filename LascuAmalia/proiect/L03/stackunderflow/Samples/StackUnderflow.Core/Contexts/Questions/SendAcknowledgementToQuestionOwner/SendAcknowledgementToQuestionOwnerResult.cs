using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner
{
    [AsChoice]
    public  static partial class SendAcknowledgementToQuestionOwnerResult
    {
        public interface ISendAcknowledgementToQuestionOwnerResult { }

        public class AcknowledgementSent : ISendAcknowledgementToQuestionOwnerResult
        {

            public AcknowledgementSent(int questionId, int questionOwnerId)
            {
                QuestionId = questionId;
                QuestionOwnerId = questionOwnerId;
            }
            public int QuestionId { get; }
            public int QuestionOwnerId { get; }
        }

        public class AcknowledgementNotSent : ISendAcknowledgementToQuestionOwnerResult
        {

            public AcknowledgementNotSent(string message)
            {
                Message = message;
            }
            public string Message { get; }
        }

    }
}
