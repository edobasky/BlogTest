using BlogtestAssessment.Features.Commands.CreateBlog;
using BlogtestAssessment.Repository.Interface;
using BlogUnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUnitTest.BlogTypes.Commands
{
    public class CreateBlogCommandHandlerTest
    {
        private readonly Mock<IRepositoryUnitofWork> _blogRepositoryUnitOfWorkMock;

        public CreateBlogCommandHandlerTest()
        {
            _blogRepositoryUnitOfWorkMock = MockBlogRepository.unitOfWorkMockRepo();
        }

        [Fact]
        public async Task CreateBlogTestPass()
        {
            var handler = new CreateBlogCommandHandler(_blogRepositoryUnitOfWorkMock.Object);

              var result = await handler.Handle(new CreateBlogCommand() {AuthorId = 4, Name = "AWS", Url = "www.aws.com" }, default);

            result.Succeeded.ShouldBeTrue();

           
        }

        [Fact]
        public async Task CreateBlogTestFail()
        {
            var handler = new CreateBlogCommandHandler(_blogRepositoryUnitOfWorkMock.Object);

             var result = await handler.Handle(new CreateBlogCommand() {}, default);

            result.Succeeded.ShouldBeFalse();


        }
    }
}
