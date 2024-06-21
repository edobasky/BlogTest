using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;
using System.Collections.Generic;

namespace BlogtestAssessment.Features.Queries.BlogPosts
{
    public class GetBlogsPostHandler : IRequestHandler<GetBlogsPost, Response<IEnumerable<BlogPostReturnDto>>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public GetBlogsPostHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<IEnumerable<BlogPostReturnDto>>> Handle(GetBlogsPost request, CancellationToken cancellationToken)
        {
            var blogPosts = await _unitofWork.PostRepository.GetAllPostInABlog(request.Id, false);

            if (!blogPosts.Any()) return Response<IEnumerable<BlogPostReturnDto>>.Fail("There no post in this blog");

            var blogPostReturnMapped = blogPosts.Select(bp => new BlogPostReturnDto()
            {
                id = bp.id,
                Ttle = bp.Ttle,
                Content = bp.Content,
                DatePublished = bp.DatePublished,
                BlogId = bp.BlogId
            });
          

            return Response<IEnumerable<BlogPostReturnDto>>.Success("Blog post query successful", blogPostReturnMapped);
        }
    }
}
