using BlogAPIExample.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class UpdateBlogPostRequest
    {
        public Guid HeaderId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

    public class UpdateBlogPost
    {
        BlogDbContext _blogDbContext;
        UpdateBlogPostRequest _updateBlogPostRequest;
        public UpdateBlogPost(BlogDbContext blogDbContext, UpdateBlogPostRequest updateBlogPostRequest)
        {
            _blogDbContext = blogDbContext;
            _updateBlogPostRequest = updateBlogPostRequest;
        }

        public bool Run()
        {
            var blogPostHeader = _blogDbContext.BlogPostHeaders.Where(p => p.Id == _updateBlogPostRequest.HeaderId).FirstOrDefault();

            if (blogPostHeader != null)
            {
                var blogPostDetail = _blogDbContext.BlogPostDetails.Where(p => p.HeaderId == _updateBlogPostRequest.HeaderId).FirstOrDefault();
                blogPostHeader.UpdatedAt = DateTime.Now;
                blogPostHeader.CategoryName = _updateBlogPostRequest.CategoryName;
                blogPostHeader.Title = _updateBlogPostRequest.Title;
                blogPostDetail.Text = _updateBlogPostRequest.Text;

                _blogDbContext.Entry(blogPostHeader).State = EntityState.Modified;
                _blogDbContext.Entry(blogPostDetail).State = EntityState.Modified;

                _blogDbContext.SaveChanges();

                return true;
            }
            else
            {
                throw new Exception("Bu Id'ye sahip bir blog yazısı bulunamadı.");
            }
        }
    }
}
