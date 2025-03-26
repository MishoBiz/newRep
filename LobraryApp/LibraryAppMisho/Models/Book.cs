using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAppMisho.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        public int PublishedYear { get; set; }

        [Required]
        public string Status { get; set; } = "Available"; // Available or Borrowed

        // Foreign Key to User (Nullable - means not borrowed)
        public int? BorrowedById { get; set; }
        [ForeignKey("BorrowedById")]
        public User? BorrowedBy { get; set; }
    }
}
