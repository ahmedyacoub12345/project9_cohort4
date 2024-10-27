using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project9_cohort4.Server.Common;
using project9_cohort4.Server.DTOs;
using project9_cohort4.Server.Models;

namespace project9_cohort4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(MyDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllUser()
        {
            var data = context.Users.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult updateUser([FromBody]RegisterDTO user) 
        {
            var data = new User
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = PasswordHasher.HashPassword( user.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsAdmin = false
            };
            context.Users.Add(data);
            context.SaveChanges();
            return Ok(data);
        }
    }
}
