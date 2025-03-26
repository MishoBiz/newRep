using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Libraryapp2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        public int PublishedYear { get; set; }

        public string Status { get; set; } = "Available"; // Default status

        [ForeignKey(nameof(BorrowedBy))]
        public string BorrowedById { get; set; }

        // Navigation Property for the related user (borrower)
        public User BorrowedBy { get; set; }
    }
}
