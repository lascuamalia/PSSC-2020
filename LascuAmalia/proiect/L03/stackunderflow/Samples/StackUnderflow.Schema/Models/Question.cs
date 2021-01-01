using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string Titlu { get; set; }
        public string Text { get;  set; }
        public string Tags { get; set; }

       

       
    }
}
