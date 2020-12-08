using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get;  set; }
        public string Tags { get; set; }

        public int Voturi { get;  set; }

       
    }
}
