using BlogtestAssessment.Features.Commands.CreateAuthor;
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
    public class CreateAuthorCommandHandlerTest
    {
        private readonly Mock<IRepositoryUnitofWork> _blogRepositoryUnitOfWorkMock;
        public CreateAuthorCommandHandlerTest()
        {
            _blogRepositoryUnitOfWorkMock = MockBlogRepository.unitOfWorkMockRepo();
        }


        [Fact]
        public async Task RegisterAuthorTestPass()
        {
            var handler = new CreateAuthorCommandHandler(_blogRepositoryUnitOfWorkMock.Object);

            var result = await handler.Handle(new CreateAuthorCommand() { Email = "edore@gmail.com", Name = "Edore Emma"}, default);

            result.ShouldBeTrue();
        }

        [Fact]
        public async Task RegisterAuthorTestFail()
        {
            var handler = new CreateAuthorCommandHandler(_blogRepositoryUnitOfWorkMock.Object);

            var result = await handler.Handle(new CreateAuthorCommand() { }, default);

            result.ShouldBeFalse();
        }
    }
}
