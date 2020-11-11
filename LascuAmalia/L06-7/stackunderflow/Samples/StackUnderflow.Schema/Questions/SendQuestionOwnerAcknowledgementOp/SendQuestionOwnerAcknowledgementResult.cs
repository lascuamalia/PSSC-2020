using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp
{
    [AsChoice]
    public static partial class SendQuestionOwnerAcknowledgementResult
    {
        public interface ISendQuestionOwnerAcknowledgementResult { }

        public class AcknowledgementSent : ISendQuestionOwnerAcknowledgementResult
        {
            public AcknowledgementSent(int questionId, Guid questionOwnerId)
            {
                QuestionId = questionId;
                QuestionOwnerId = questionOwnerId;
            }

            public int QuestionId { get; }
            public Guid QuestionOwnerId { get; }
        }

        public class AcknowledgementNotSent : ISendQuestionOwnerAcknowledgementResult
        {
            public AcknowledgementNotSent(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
