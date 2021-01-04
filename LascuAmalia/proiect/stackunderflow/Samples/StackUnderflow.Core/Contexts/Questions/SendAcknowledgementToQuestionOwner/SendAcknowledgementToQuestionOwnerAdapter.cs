using Access.Primitives.IO;

using System;
using System.Collections.Generic;
using System.Text;
using GrainInterfaces;
using System.Threading.Tasks;
using Orleans;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner.SendAcknowledgementToQuestionOwnerResult;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendAcknowledgementToQuestionOwner
{
    class SendAcknowledgementToQuestionOwnerAdapter : Adapter<SendAcknowledgementToQuestionOwnerCmd, ISendAcknowledgementToQuestionOwnerResult, QuestionsWriteContext, QuestionsDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendAcknowledgementToQuestionOwnerAdapter(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        public override Task PostConditions(SendAcknowledgementToQuestionOwnerCmd cmd, ISendAcknowledgementToQuestionOwnerResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendAcknowledgementToQuestionOwnerResult> Work(SendAcknowledgementToQuestionOwnerCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>("user1");
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync("email@address.com");
            return new AcknowledgementSent(1, 2);
        }
    }
}
