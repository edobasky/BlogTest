using BlogtestAssessment.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogtestAssessment.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Author>?  Authors { get; set; }

        public DbSet<Blog>?  Blogs { get; set; }

        public DbSet<Post>? Posts { get; set; }

    }
}
