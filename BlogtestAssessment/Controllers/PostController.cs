using BlogtestAssessment.Features.Commands.CreatePost;
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
    }
}
