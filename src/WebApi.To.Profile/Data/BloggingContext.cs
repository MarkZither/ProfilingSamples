using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace WebApi.To.Profile.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; private set; }
        public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(new Blog { BlogId = 1, Url = "http://sample.com" });

            modelBuilder.Entity<Post>().HasData(
                new Post { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" });
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
