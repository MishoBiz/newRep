using LobraryApp.Enums;
using Microsoft.AspNetCore.Identity;

namespace LobraryApp.Data.Entities;

public class Book : BaseEntity<int>
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Genre { get; set; } = default!;
    
    
    public DateTime PublishDate { get; set; } = default!;
    public Status Status { get; set; } = default!;
    
    public IdentityUser BorrowedBy { get; set; } = default!;
}