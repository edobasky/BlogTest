using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;

namespace BlogtestAssessment.Features.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand,Response<BlogCreateResponseDto>>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public CreateBlogCommandHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Response<BlogCreateResponseDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {

            if (request.Url is null || request.Name is null) return Response<BlogCreateResponseDto>.Fail("Empty property values not allows");

            // Check Author exist

                    var authorCheck = await _unitofWork.AuthorRepository.CheckAuthorExistById(request.AuthorId, false);

                    if (!authorCheck) return Response<BlogCreateResponseDto>.Fail("The Author does not exist, please create the author of the blog and try again");



            Blog blogToCreateMapping = new Blog()
            {
                Name = request.Name,
                Url = request.Url,
                AuthorId = request.AuthorId,
            };


            _unitofWork.BlogRepository.CreateNewBlog(blogToCreateMapping);
            int successfulCommit = await _unitofWork.SaveAsync();

            if (successfulCommit > 0)
            {
                return Response<BlogCreateResponseDto>.Success("Blog Creation Successful",new BlogCreateResponseDto { Name = blogToCreateMapping.Name, Url = blogToCreateMapping.Url} );
            }

            return Response<BlogCreateResponseDto>.Fail("Blog Creation not Successful");
        }

        

    }
}
