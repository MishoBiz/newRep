using LibraryAppMisho.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppMisho.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
