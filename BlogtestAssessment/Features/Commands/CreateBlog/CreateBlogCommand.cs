using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Utilities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BlogtestAssessment.Features.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<Response<BlogCreateResponseDto>>
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Url { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
