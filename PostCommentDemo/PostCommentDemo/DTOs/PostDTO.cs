using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCommentDemo.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime PostTime { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }

        public PostDTO() { 
            Comments = new List<CommentDTO>();
            
        }
    }
}