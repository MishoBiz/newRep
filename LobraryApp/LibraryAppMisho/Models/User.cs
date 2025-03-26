using System.ComponentModel.DataAnnotations;

namespace LibraryAppMisho.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store hashed password

        [Required]
        public string Role { get; set; } = "User"; // Default role is User

        public ICollection<Book> BorrowedBooks { get; set; } // Navigation property
    }
}
