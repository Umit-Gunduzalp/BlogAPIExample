using BlogAPIExample.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class DeleteBlogPostRequest
    {
        public Guid HeaderId { get; set; }
    }

    public class DeleteBlogPost
    {
        BlogDbContext _blogDbContext;
        DeleteBlogPostRequest _deleteBlogPostRequest;
        public DeleteBlogPost(BlogDbContext blogDbContext, DeleteBlogPostRequest deleteBlogPostRequest)
        {
            _blogDbContext = blogDbContext;
            _deleteBlogPostRequest = deleteBlogPostRequest;
        }

        public bool Run()
        {
            var blogPostHeader = _blogDbContext.BlogPostHeaders.Where(p => p.Id == _deleteBlogPostRequest.HeaderId).FirstOrDefault();

            if (blogPostHeader != null)
            {
                blogPostHeader.DeletedAt = DateTime.Now;
                blogPostHeader.IsDelete = true;
                _blogDbContext.Entry(blogPostHeader).State = EntityState.Modified;

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
