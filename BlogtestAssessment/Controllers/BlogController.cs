using BlogtestAssessment.Features.Commands.CreateBlog;
using BlogtestAssessment.Features.Queries.BlogAuthor;
using BlogtestAssessment.Features.Queries.Blogs;
using BlogtestAssessment.Models.Dto;
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

        [HttpGet("AuthorId")]
        public async Task<IActionResult> GetBlogsByAuthor(int AuthorId)
        {
            var response = await _sender.Send(new GetBlogsByAuthorQuery() { Id = AuthorId});

            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var response = await _sender.Send(new GetBlogsQuery() {});

            return Ok(response);
        }

    }
}
