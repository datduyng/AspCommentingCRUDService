using System;
using System.ComponentModel.DataAnnotations;

namespace AspMultiTenantCommentAPI.DTO
{
    public class CommentDTO
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ThreadId { get; set; }

        public int? ParentCommentId { get; set; }
    }
}
