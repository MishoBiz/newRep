using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Libraryapp2.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string Role { get; set; } = "User"; // Default role
    }
}
