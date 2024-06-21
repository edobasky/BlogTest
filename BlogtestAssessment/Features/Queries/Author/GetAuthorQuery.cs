using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Queries.Author
{
    public class GetAuthorQuery : IRequest<Response<IEnumerable<AuthorReturnDto>>>
    {
    }
}
