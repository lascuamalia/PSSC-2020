using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackOverflow.Domain.Schema.Questions.AskQuestionOp
{
   public  class AskQuestionCmd
    {

        public AskQuestionCmd(string question)
        {
            Question = question;
        }

        [MinLength(10)]
        public string Question { get; }
    }
}
