﻿using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Backoffice.Questions
{
    public class QuestionsWriteContext
    {
        public ICollection<Question> Questions { get; }
        public QuestionsWriteContext(ICollection<Question> questions)
        {
            Questions = questions ?? new List<Question>();
        }

    }
}
