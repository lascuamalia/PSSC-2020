using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions
{
   public class QuestionsWriteContextC
    {
        public ICollection<Question> Questions { get; }
        public QuestionsWriteContextC(ICollection<Question> questions)
        {
            Questions = questions ?? new List<Question>();
        }
    }
}
