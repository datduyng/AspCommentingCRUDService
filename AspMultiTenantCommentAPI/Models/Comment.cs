using System;
using System.Collections.Generic;

namespace AspMultiTenantCommentAPI.Models
{
    public class Comment
    {
        public Comment()
        {
            this.ChildrenComment = new List<Comment>();
        }

        public int CommentId { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }

        public int? ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
        
        public ICollection<Comment> ChildrenComment { get; set; }
    }
}
