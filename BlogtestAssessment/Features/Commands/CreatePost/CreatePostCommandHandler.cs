using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Response<PostToCreateResponse>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public CreatePostCommandHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<PostToCreateResponse>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post postToCreateMapping = new Post()
            {
                Ttle = request.Ttle,
                Content = request.Content,
                BlogId = request.BlogId,
            };

            bool BlogExist = await _unitofWork.BlogRepository.CheckBlogExist(request.BlogId, false);

            if (!BlogExist)
            {
                return Response<PostToCreateResponse>.Fail("The blog for this post does not exist, please create a new blog and try again");
            }

             _unitofWork.PostRepository.CreateNewPost(postToCreateMapping);
            int successfulCommit = await _unitofWork.SaveAsync();

            if (successfulCommit > 0)
            {
                return Response<PostToCreateResponse>.Success("Post created successfully", new PostToCreateResponse() { Id = postToCreateMapping.id, Title = postToCreateMapping.Ttle });
            }

            return Response<PostToCreateResponse>.Fail("Failed to create a new post, please try again or contact support.");
        }
    }
}
