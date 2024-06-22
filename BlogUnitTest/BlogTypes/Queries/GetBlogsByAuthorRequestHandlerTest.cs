using BlogtestAssessment.Features.Queries.BlogAuthor;
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
    public class GetBlogsByAuthorRequestHandlerTest
    {
        private readonly Mock<IRepositoryUnitofWork> _blogRepositoryUnitOfWorkMock;

        public GetBlogsByAuthorRequestHandlerTest()
        {
            _blogRepositoryUnitOfWorkMock = MockBlogRepository.unitOfWorkMockRepo();
        }

        [Fact]
        public async Task GetBlogByAuthorTestPasss()
        {
            // Arrange
            var handler = new GetBlogsByAuthorQueryHandler(_blogRepositoryUnitOfWorkMock.Object);

            //Acy

            var result = await handler.Handle(new GetBlogsByAuthorQuery() { Id = 5}, default);

            // Assert

             result.Data.Count().ShouldBe(3);

             result.Data.ShouldNotBeNull();

             result.Succeeded.ShouldBeTrue();  
        }

        [Fact]
        public async Task GetBlogByAuthorTestFail()
        {
            // Arrange
            var handler = new GetBlogsByAuthorQueryHandler(_blogRepositoryUnitOfWorkMock.Object);

            // Act

            var result = await handler.Handle(new GetBlogsByAuthorQuery() { }, default);

            var result2 = await handler.Handle(new GetBlogsByAuthorQuery() { Id = 2 }, default);


            //Assert

            result.Data.ShouldBeNull();
            result.Message.ShouldBe("The Author has no Blogs");
            result2.Succeeded.ShouldBeFalse();
            result2.Data.ShouldBeNull();

          
        }
    }
}
