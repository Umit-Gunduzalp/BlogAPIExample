using BlogAPIExample.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Features
{
    public class GetPopularBlogPosts
    {
        BlogDbContext _blogDbContext;
        public int _count { get; set; }
        public string _categoryName { get; set; }

        public GetPopularBlogPosts(BlogDbContext blogDbContext, int count, string categoryName)
        {
            _blogDbContext = blogDbContext;
            _count = count;
            _categoryName = categoryName;
        }

        public List<GetBlogPostsResponse> Run()
        {
            var blogPostHeaders = _blogDbContext.BlogPostHeaders
                                                .Where(p => !p.IsDelete && p.CategoryName == (_categoryName != null && _categoryName != "" ? _categoryName : p.CategoryName))
                                                .OrderByDescending(p => p.CounterOfReads)
                                                .Take(_count)
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
