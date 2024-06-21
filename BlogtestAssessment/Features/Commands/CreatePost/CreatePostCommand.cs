using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Utilities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Features.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<Response<PostToCreateResponse>>
    {
        [Required]
        public string? Ttle { get; set; }

        [Required]
        public string? Content { get; set; }
        public int BlogId { get; set; }
    }
}
