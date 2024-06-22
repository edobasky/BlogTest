using BlogtestAssessment.Features.Queries.Blogs;
using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using BlogUnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUnitTest.BlogTypes.Queries
{
    public class GetAllBlogsRequestHandlerTest
    {
        private readonly Mock<IRepositoryUnitofWork> _blogRepositoryUnitOfWorkMock;

        public GetAllBlogsRequestHandlerTest()
        {
            _blogRepositoryUnitOfWorkMock = MockBlogRepository.unitOfWorkMockRepo();
        }

        [Fact]
        public async Task<Response<IEnumerable<BlogReturnResponseDto>>> GetAllBlogs()
        {
            //Arrange
            var handler = new GetBlogsQueryHandler(_blogRepositoryUnitOfWorkMock.Object);

            //Act

            var result = await handler.Handle(new GetBlogsQuery() { }, default);


            //Assert

            result.ShouldBeOfType<Response<IEnumerable<BlogReturnResponseDto>>>();
          
          // result.ShouldBeNull();

            return result;
        }
    }
}
