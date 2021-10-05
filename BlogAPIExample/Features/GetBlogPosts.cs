using BlogAPIExample.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class GetBlogPostsResponse
    {
        public Guid HeaderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public int CounterOfReads { get; set; }
    }

    public class GetBlogPosts
    {
        BlogDbContext _blogDbContext;
        public int _pageNumber { get; set; }
        public int _pageSize { get; set; }
        public string _categoryName { get; set; }

        public GetBlogPosts(BlogDbContext blogDbContext, int pageNumber, int pageSize, string categoryName)
        {
            _blogDbContext = blogDbContext;
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _categoryName = categoryName;
        }

        public List<GetBlogPostsResponse> Run()
        {
            var blogPostHeaders = _blogDbContext.BlogPostHeaders
                                                .Where(p => !p.IsDelete && p.CategoryName == (_categoryName != null && _categoryName != "" ? _categoryName : p.CategoryName))
                                                .OrderByDescending(p => p.UpdatedAt)
                                                .Skip((_pageNumber - 1) * _pageSize)
                                                .Take(_pageSize)
                                                .Select(p => new GetBlogPostsResponse() { 
                                                     CreatedAt = p.CreatedAt,
                                                     UpdatedAt = p.UpdatedAt,
                                                     HeaderId = p.Id,
                                                     CategoryName = p.CategoryName,
                                                     Title = p.Title,
                                                     CounterOfReads = p.CounterOfReads
                                                })
                                                .ToList();
            return blogPostHeaders;
        }
    }
}
