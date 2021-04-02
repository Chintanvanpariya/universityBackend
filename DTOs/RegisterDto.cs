using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityServer.DTOs
{
    public class RegisterDto
    {
        [Required] public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }

        [Required] public string Name { get; set; }
        [Required] public string Gender { get; set; } = "Unknown";
        public DateTime DateOfBirth { get; set; }

    }
}