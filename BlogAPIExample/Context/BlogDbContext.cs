using BlogAPIExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPIExample.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext([NotNullAttribute] DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPostHeader> BlogPostHeaders { get; set; }

        public DbSet<BlogPostDetail> BlogPostDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPostHeader>().HasIndex(b => new { b.CategoryName });
            modelBuilder.Entity<BlogPostHeader>().HasIndex(b => new { b.CounterOfReads });
            modelBuilder.Entity<BlogPostDetail>().HasIndex(b => new { b.HeaderId });
        }
    }
}
