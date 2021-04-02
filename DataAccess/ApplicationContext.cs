using Microsoft.EntityFrameworkCore;

namespace SbornikBackend.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Content>Contents{ get; set; }
        public DbSet<Faculty>Faculties { get; set; }
        public DbSet<GuideSection> Guide { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<MainArticle> MainArticles { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Hashtag>Hashtags { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HashtagToPostRelation>HashtagsToPostsRelation { get; set; }
        public ApplicationContext():base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            
        }
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_sbornik;Username=postgres;Password=sarang");
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Content>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (ContentType)Enum.Parse(typeof(ContentType), v));
        }*/
    }
}