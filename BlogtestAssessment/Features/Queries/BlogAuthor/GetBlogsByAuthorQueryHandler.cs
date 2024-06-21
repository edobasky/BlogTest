using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;
using System.Collections.Generic;

namespace BlogtestAssessment.Features.Queries.BlogAuthor
{
    public class GetBlogsByAuthorQueryHandler : IRequestHandler<GetBlogsByAuthorQuery, Response<IEnumerable<BlogReturnResponseDto>>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public GetBlogsByAuthorQueryHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<IEnumerable<BlogReturnResponseDto>>> Handle(GetBlogsByAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogsQuery = await _unitofWork.BlogRepository.GetAllBlogsByAnAuthor(request.Id,false,cancellationToken);


            if (blogsQuery == null || !blogsQuery.Any())
            {
                return Response<IEnumerable<BlogReturnResponseDto>>.Fail("The Author has no Blogs");
            }

            return Response<IEnumerable<BlogReturnResponseDto>>.Success("query successful",blogsQuery);


        }
    }
}
