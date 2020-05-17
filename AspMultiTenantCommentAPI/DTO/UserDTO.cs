using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspMultiTenantCommentAPI.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
