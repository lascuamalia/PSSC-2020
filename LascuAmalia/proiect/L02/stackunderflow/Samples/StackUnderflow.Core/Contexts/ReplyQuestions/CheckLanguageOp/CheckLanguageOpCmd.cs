using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.ReplyQuestions.CheckLanguageOp
{
   public class CheckLanguageOpCmd
    {
        public CheckLanguageOpCmd(string text)
        {
            Text = text;
        }

        [Required]
        public string Text { get; set; }
    }
}

