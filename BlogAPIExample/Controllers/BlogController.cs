using BlogAPIExample.Context;
using BlogAPIExample.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlogAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        BlogDbContext _blogDbContext;
        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        [HttpPost("CreateBlogPost")]
        public bool CreateBlogPost([FromBody] CreateBlogPostRequest createBlogPostRequest)
        {
            var createBlogPost = new CreateBlogPost(_blogDbContext, createBlogPostRequest);
            return createBlogPost.Run();
        }

        [HttpPut("UpdateBlogPost")]
        public bool UpdateBlogPost([FromBody] UpdateBlogPostRequest updateBlogPostRequest)
        {
            var updateBlogPost = new UpdateBlogPost(_blogDbContext, updateBlogPostRequest);
            return updateBlogPost.Run();
        }

        [HttpDelete("DeleteBlogPost")]
        public bool DeleteBlogPost([FromBody] DeleteBlogPostRequest deleteBlogPostRequest)
        {
            var deleteBlogPost = new DeleteBlogPost(_blogDbContext, deleteBlogPostRequest);
            return deleteBlogPost.Run();
        }

        [HttpGet("GetBlogPosts")]
        public List<GetBlogPostsResponse> GetBlogPosts(int pageNumber, int pageSize, string categoryName)
        {
            var getBlogPosts = new GetBlogPosts(_blogDbContext, pageNumber, pageSize, categoryName);
            return getBlogPosts.Run();
        }

        [HttpGet("GetPopularBlogPosts")]
        public List<GetBlogPostsResponse> GetPopularBlogPosts(int count, string categoryName)
        {
            var getBlogPosts = new GetPopularBlogPosts(_blogDbContext, count, categoryName);
            return getBlogPosts.Run();
        }

        [HttpGet("GetBlogPost")]
        public GetBlogPostResponse GetBlogPost(Guid headerId)
        {
            var getBlogPost = new GetBlogPost(_blogDbContext, headerId);
            return getBlogPost.Run();
        }
    }
}
