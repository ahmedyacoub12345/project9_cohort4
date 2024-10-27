using Microsoft.Build.Framework;

namespace project9_cohort4.Server.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } 
        [Required]
        public string Email { get; set; } 
        public string Password { get; set; } 
    }
}
