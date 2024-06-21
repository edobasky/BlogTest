using BlogtestAssessment.Features.Commands.CreatePost;
using BlogtestAssessment.Features.Queries.BlogPosts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogtestAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ISender _sender;

        public PostController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPost(CreatePostCommand postCreate)
        {
            var postCreationResponse = await _sender.Send(postCreate);
            return Ok(postCreationResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost(int blogId)
        {
            var blogPostsResponse = await _sender.Send(new GetBlogsPost() { Id = blogId});

            return Ok(blogPostsResponse);
        }
    }
}
