using BlogtestAssessment.Features.Commands.CreateBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogtestAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ISender _sender;

        public BlogController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBlog(CreateBlogCommand createBlog)
        {
            var response = await _sender.Send(createBlog);

            return Ok(response);
        }
    }
}
