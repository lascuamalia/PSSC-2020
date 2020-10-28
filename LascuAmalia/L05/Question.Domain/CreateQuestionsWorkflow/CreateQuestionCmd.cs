using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateQuestionsWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        
        public string Text { get; private set; }

        public int Voturi { get; private set; }

        [Required]
        
        public string[] Tags { get;  set; }
        public CreateQuestionCmd(string text, int voturi, string[] tags)
        {
            Text = text;
            Voturi = voturi;
            Tags = tags;

        }

       
    }

  
}
