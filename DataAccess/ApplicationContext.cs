using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using System.Data;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace SbornikBackend.DataAccess
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sbornik_database;Username=postgres;Password=sarang");
        }
        public Microsoft.EntityFrameworkCore.DbSet<Content> Contents{ get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Faculty>Faculties { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<GuideSection> Guide { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Article> Articles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<MainArticle> MainArticles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Section> Sections { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Hashtag>Hashtags { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Post>Posts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        
    }
}