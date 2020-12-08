using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CreateReplyOp;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.SendQuestionOwnerAcknowledgementOp;
using StackUnderflow.Domain.Core.Contexts.ReplyQuestions.SendReplyAuthorAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp.CheckLanguageOpResult;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CreateReplyOp.CreateReplyResult;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions
{
   public static class QuestionsContextOp
    {

        public static Port<ICreateReplyResult> CreateReply(CreateReplyCmd createReplyCmd) =>
          NewPort<CreateReplyCmd, ICreateReplyResult>(createReplyCmd);

        public static Port<ICheckLanguageOpResult> CheckLanguage(CheckLanguageOpCmd checkLanguageOpCmd) =>
            NewPort<CheckLanguageOpCmd, ICheckLanguageOpResult>(checkLanguageOpCmd);

        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgement(SendQuestionOwnerAcknowledgementCmd cmd) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(cmd);

        public static Port<ISendReplyAuthorAcknowledgementResult> SendReplyAuthorAcknowledgement(SendReplyAuthorAcknowledgementCmd cmd) =>
           NewPort<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult>(cmd);
    }
}
