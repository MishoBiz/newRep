using System.ComponentModel.DataAnnotations;

namespace bookLibrary.Models
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

        public string BorrowedById { get; set; }
        public ApplicationUser BorrowedBy { get; set; }
    }
}
