using BlogAPIExample.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class GetBlogPostResponse
    {
        public Guid HeaderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CounterOfReads { get; set; }
    }

    public class GetBlogPost
    {
        BlogDbContext _blogDbContext;
        public Guid _headerId { get; set; }

        public GetBlogPost(BlogDbContext blogDbContext, Guid headerId)
        {
            _blogDbContext = blogDbContext;
            _headerId = headerId;
        }

        public GetBlogPostResponse Run()
        {
            var blogPostHeader = _blogDbContext.BlogPostHeaders
                                               .Where(p => p.Id == _headerId)
                                               .FirstOrDefault();
            if (blogPostHeader != null)
            {
                var blogPostDetail = _blogDbContext.BlogPostDetails.Where(p => p.HeaderId == _headerId).FirstOrDefault();

                blogPostHeader.CounterOfReads += 1;
                _blogDbContext.Entry(blogPostHeader).State = EntityState.Modified;
                _blogDbContext.SaveChanges();

                var getBlogPostResponse = new GetBlogPostResponse()
                {
                    HeaderId = blogPostHeader.Id,
                    CategoryName = blogPostHeader.CategoryName,
                    Title = blogPostHeader.Title,
                    CreatedAt = blogPostHeader.CreatedAt,
                    UpdatedAt = blogPostHeader.UpdatedAt,
                    CounterOfReads = blogPostHeader.CounterOfReads,
                    Text = blogPostDetail.Text
                };

                return getBlogPostResponse;
            }
            else
            {
                throw new Exception("Bu Id'ye sahip bir blog yazısı bulunamadı.");
            }
        }
    }
}
