using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Schema.Questions.CreateAnswerOp
{
    public class CreateReplyCmd
    {
        public CreateReplyCmd(int questionId, Guid authorUserId,Guid questionOwnerId, string body)
        {
            QuestionId = questionId;
            AuthorUserId = authorUserId;
            Body = body;
            QuestionOwnerId = questionOwnerId;
        }
        [Required]
        public int QuestionId { get; }
        [Required]
        public Guid AuthorUserId { get; }
        [Required]
        [StringRange(10, 500)]
        // [MinLength(10)]
        //[MaxLength(500)]
        public string Body { get; }
        public Guid QuestionOwnerId { get; }
        //public Guid ReplyAuthorId { get; set; }
    }
}
