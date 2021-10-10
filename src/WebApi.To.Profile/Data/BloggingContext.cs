using System;
using System.Collections.Generic;

using Bogus;
using Bogus.Extensions;

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
            var ids = 1;
            var blog = new Faker<Blog>()
                .RuleFor(m => m.BlogId, f => ids++)
                .RuleFor(m => m.Url, f => f.Internet.Url());
            List<Blog> blogs = blog.GenerateBetween(100, 150);
            modelBuilder.Entity<Blog>().HasData(blogs);

            var postids = 1;
            var lorem = new Bogus.DataSets.Lorem("en");
            var post = new Faker<Post>()
                .RuleFor(m => m.PostId, f => postids++)
                .RuleFor(m => m.Title, lorem.Slug())
                .RuleFor(m => m.Content, lorem.Sentence(400, 300))
                .RuleFor(m => m.BlogId, m => m.PickRandom(blogs).BlogId);
            modelBuilder.Entity<Post>().HasData(post.GenerateBetween(1000, 1500));
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
