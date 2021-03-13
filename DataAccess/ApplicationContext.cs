using Microsoft.EntityFrameworkCore;

namespace SbornikBackend.DataAccess
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<GuideSection> Guide { get; set; }
    }
}