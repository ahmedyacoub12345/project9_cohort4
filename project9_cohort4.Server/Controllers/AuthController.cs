using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using project9_cohort4.Server.Common;
using project9_cohort4.Server.DTOs;
using project9_cohort4.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace project9_cohort4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(MyDbContext context, IConfiguration config) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginData)
        {
            var hashedPassword = PasswordHasher.HashPassword(loginData.Password);
            var user = context.Users.FirstOrDefault(u => u.Email == loginData.Email && u.PasswordHash == hashedPassword);
            if (user == null)
                return Unauthorized("Email and password not match.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId))
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(config["Jwt:Expires"])),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
        [HttpPost("register")]
        public IActionResult updateUser([FromBody] RegisterDTO user)
        {
            var data = new User
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = PasswordHasher.HashPassword(user.Password),
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
