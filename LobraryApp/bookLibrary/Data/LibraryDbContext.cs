using bookLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookLibrary.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
    }
}
