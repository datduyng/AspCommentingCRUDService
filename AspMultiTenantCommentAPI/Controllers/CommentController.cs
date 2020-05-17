using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using AspMultiTenantCommentAPI.Models;
using AspMultiTenantCommentAPI.DTO;
using AspMultiTenantCommentAPI.ViewModels;

namespace AspMultiTenantCommentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly DBContext _dBContext;

        private readonly ILogger<WeatherForecastController> _logger;

        public CommentController(ILogger<WeatherForecastController> logger, DBContext context)
        {
            _logger = logger;
            _dBContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments(int ThreadId)
        {
            var queue = _dBContext.Comments
                        .Where(t => (t.ThreadId == ThreadId))
                        .Include(c => c.ParentComment)
                        .ToList() // NOTE here. ToList will create a deep copy of each nested object.
                                  //The following Where would filter out the non first level comments levels without removing itself fromthe children. 
                        .Where(t => (t.ParentCommentId == null))
                        .ToList();
            return queue;
        }

        [HttpPost]
        public async Task<Comment> Post(CommentDTO commentDTO)
        {
            var comment = new Comment() {
                UserId = commentDTO.UserId,
                ThreadId = commentDTO.ThreadId,
                Description = commentDTO.Description,
                ParentCommentId = commentDTO.ParentCommentId
            };
            await _dBContext.Comments.AddAsync(comment);
            await _dBContext.SaveChangesAsync();
            return comment;
        }
    }

}
