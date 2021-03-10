using System.Collections.Generic;
using GenericRepositoryDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryDemo
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}