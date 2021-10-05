using BlogAPIExample.Context;
using BlogAPIExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class CreateBlogPostRequest
    {
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class CreateBlogPost
    {
        BlogDbContext _blogDbContext;
        CreateBlogPostRequest _createBlogPostRequest;
        public CreateBlogPost(BlogDbContext blogDbContext, CreateBlogPostRequest createBlogPostRequest)
        {
            _blogDbContext = blogDbContext;
            _createBlogPostRequest = createBlogPostRequest;
        }

        public bool Run()
        {
            var blogPostHeader = new BlogPostHeader()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CategoryName = _createBlogPostRequest.CategoryName,
                Title = _createBlogPostRequest.Title,
                CounterOfReads = 0,
                IsDelete = false
            };

            var blogPostDetail = new BlogPostDetail()
            {
                Id = Guid.NewGuid(),
                HeaderId = blogPostHeader.Id,
                Text = _createBlogPostRequest.Text
            };

            _blogDbContext.BlogPostHeaders.Add(blogPostHeader);
            _blogDbContext.Entry(blogPostHeader).State = EntityState.Added;

            _blogDbContext.BlogPostDetails.Add(blogPostDetail);
            _blogDbContext.Entry(blogPostDetail).State = EntityState.Added;

            _blogDbContext.SaveChanges();

            return true;
        }
    }
}
