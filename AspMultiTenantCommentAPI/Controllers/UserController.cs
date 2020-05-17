using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using AspMultiTenantCommentAPI.Models;
using AspMultiTenantCommentAPI.DTO;

namespace AspMultiTenantCommentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBContext _dBContext;

        private readonly ILogger<WeatherForecastController> _logger;

        public UserController(ILogger<WeatherForecastController> logger, DBContext context)
        {
            _logger = logger;
            _dBContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _dBContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<User> Post(User user)
        {
            _dBContext.Users.Add(user);
            await _dBContext.SaveChangesAsync();
            return user;
        }
    }

}
