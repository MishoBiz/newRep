using ForumApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ForumApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        public DbSet<Post>  Posts {get; init;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedPosts();
            builder
                .Entity<Post>()
                .HasData(this.FirstPost, this.SecondPost, this.ThirdPost);

            base.OnModelCreating(builder);
        }
        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations in MVC. It`s so much fun!"
            };

            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "My second post will be about performing CRUD operations in MVC. It`s so much fun!"
            };

            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "My third post will be about performing CRUD operations in MVC. It`s so much fun!"
            };
        }
    }

}
