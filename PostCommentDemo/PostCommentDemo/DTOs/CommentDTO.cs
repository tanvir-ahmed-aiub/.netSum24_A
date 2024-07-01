using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCommentDemo.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Comments { get; set; }
    }
}