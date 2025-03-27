using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Director { get; set; }

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime? RentalDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [ForeignKey("RentedBy")]
        public string? RentedById { get; set; }

        public ApplicationUser? RentedBy { get; set; }
    }
}
