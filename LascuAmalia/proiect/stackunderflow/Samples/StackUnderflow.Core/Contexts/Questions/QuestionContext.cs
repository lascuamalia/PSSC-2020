using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner;

using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner.SendAcknowledgementToQuestionOwnerResult;


namespace StackUnderflow.Domain.Core.Contexts.Backoffice.Questions
{
    public static class QuestionContext
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd) =>
            NewPort<CreateQuestionCmd, ICreateQuestionResult>(createQuestionCmd);

        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
           NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);
        
        public static Port<ISendAcknowledgementToQuestionOwnerResult> SendAcknowledgementToQuestionOwner(SendAcknowledgementToQuestionOwnerCmd sendAckToQuestionOwnerCmd) =>
            NewPort<SendAcknowledgementToQuestionOwnerCmd, ISendAcknowledgementToQuestionOwnerResult>(sendAckToQuestionOwnerCmd);

        

    }
}
