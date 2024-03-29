﻿using Microsoft.EntityFrameworkCore;

namespace SbornikBackend.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Content>Contents{ get; set; }
        public DbSet<Faculty>Faculties { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<GuideSection> Guide { get; set; }
        public DbSet<Hashtag>Hashtags { get; set; }
        public DbSet<Post>Posts { get; set; }
        public DbSet<UserBot> UsersBot { get; set; }
        public DbSet<UserDesktop> UsersDesktop { get; set; }

        public DbSet<HashtagToPostRelation>HashtagsToPostsRelation { get; set; }
        public DbSet<DeaneryTypeRelation>DeaneryTypesRelation { get; set; }
        public ApplicationContext():base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}