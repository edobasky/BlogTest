using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Queries.Blogs
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, Response<IEnumerable<BlogReturnResponseDto>>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public GetBlogsQueryHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<IEnumerable<BlogReturnResponseDto>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _unitofWork.BlogRepository.GetAllBlogs(false, cancellationToken);

            if(blogs is null || !blogs.Any())
            {
                return Response<IEnumerable<BlogReturnResponseDto>>.Fail("There are no available blogs");
            }

            return Response<IEnumerable<BlogReturnResponseDto>>.Success("blogs query succesful", blogs);
        }
    }
}
