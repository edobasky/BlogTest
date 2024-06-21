using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Queries.BlogPosts
{
    public class GetBlogsPost : IRequest<Response<IEnumerable<BlogPostReturnDto>>>
    {
        public int Id { get; set; }
    }
}
