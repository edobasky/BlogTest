using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Queries.BlogAuthor
{
    public class GetBlogsByAuthorQuery : IRequest<Response<IEnumerable<BlogReturnResponseDto>>>
    {
        public int Id { get; set; }
    }
}
