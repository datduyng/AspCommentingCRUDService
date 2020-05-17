using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspMultiTenantCommentAPI.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }

        public string Uri { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
