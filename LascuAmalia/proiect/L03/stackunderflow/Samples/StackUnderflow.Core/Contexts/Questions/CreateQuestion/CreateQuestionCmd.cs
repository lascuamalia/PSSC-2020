using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    public class CreateQuestionCmd
    {
       public CreateQuestionCmd() { }
        public CreateQuestionCmd(string titlu,string text, string tags)
        {
            Titlu = titlu;
            Text = text;
           
            Tags = tags;

        }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Titlu { get; set; }

        [MinLength(10)]
        [MaxLength(500)]
        [Required]
        public string Text { get; set; }

        [Required]

        public string Tags { get; set; }
    }
}
