using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using AspMultiTenantCommentAPI.Models;

namespace AspMultiTenantCommentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadController : ControllerBase
    {
        private readonly DBContext _dBContext;

        private readonly ILogger<WeatherForecastController> _logger;

        public ThreadController(ILogger<WeatherForecastController> logger, DBContext context)
        {
            _logger = logger;
            _dBContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thread>>> GetUsers()
        {
            return await _dBContext.Threads
                    .Include(t => t.Comments)
                    .Include(t => t.User)
                    .ToListAsync();
        }

        [HttpPost]
        public async Task<Thread> Post(User user)
        {
            var uri = (Stopwatch.GetTimestamp() / 100).ToString();
            var thread = new Thread() { Uri = uri, UserId = user.UserId };
            await _dBContext.Threads.AddAsync(thread);
            await _dBContext.SaveChangesAsync();
            await _dBContext.Entry(thread).Reference(t => t.User).LoadAsync();
            return thread;
        }
    }

}
