using System;
using System.Collections.Generic;

using AspMultiTenantCommentAPI.Models;

namespace AspMultiTenantCommentAPI.ViewModels
{
    public class CommentView
    {
        public int CommentId { get; set; }

        public string Description { get; set; }

        public User User { get; set; }

        public int ThreadId { get; set; }

        public ICollection<Comment> ChildrenComment { get; set; }
    }
}
