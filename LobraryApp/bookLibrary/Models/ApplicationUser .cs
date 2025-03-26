using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bookLibrary.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string Role { get; set; } = "User"; // Default role
    }
}
