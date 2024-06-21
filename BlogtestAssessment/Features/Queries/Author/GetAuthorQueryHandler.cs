using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Queries.Author
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, Response<IEnumerable<AuthorReturnDto>>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public GetAuthorQueryHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<IEnumerable<AuthorReturnDto>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var Authors = await _unitofWork.AuthorRepository.GetAllAuthors(false, cancellationToken);

            if (Authors is null || !Authors.Any()) return Response<IEnumerable<AuthorReturnDto>>.Fail("No available authors");

            return Response<IEnumerable<AuthorReturnDto>>.Success("Authors query successful", Authors);
        }
    }
}
