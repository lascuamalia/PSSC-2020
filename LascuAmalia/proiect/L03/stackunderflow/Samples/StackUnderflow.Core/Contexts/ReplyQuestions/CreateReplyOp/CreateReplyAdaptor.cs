﻿using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Backoffice.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CreateReplyOp.CreateReplyResult;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CreateReplyOp
{
    class CreateReplyAdaptor: Adapter<CreateReplyCmd, ICreateReplyResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddAnswerToQuestion(state, CreateAnswerFromCmd(cmd))
                           select t;
            //aici se introduc datele, state-ul este QuestionWrite Contextul meu
             state.Replies.Add(new DatabaseModel.Models.Reply { AuthorUserId=55, Body="bodyyy 10", QuestionId=50, ReplyId=15});

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new ReplyNotCreated(ex.Message)
                );

            return result;
        }
        private ICreateReplyResult AddAnswerToQuestion(QuestionsWriteContext state, object v)
        {
            return new ReplyCreated(1, 2, 3, "My answer body");
        }

        private object CreateAnswerFromCmd(CreateReplyCmd cmd)
        {
            return new { };
        }
    }
}
