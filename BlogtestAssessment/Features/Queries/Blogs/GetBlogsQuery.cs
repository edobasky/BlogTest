using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Utilities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Features.Queries.Blogs
{
    public class GetBlogsQuery : IRequest<Response<IEnumerable<BlogReturnResponseDto>>>
    {
    }
}
