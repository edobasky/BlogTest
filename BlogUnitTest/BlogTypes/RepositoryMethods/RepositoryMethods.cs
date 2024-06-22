using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Repository.Interface;
using Moq;

namespace BlogUnitTest.BlogTypes.RepositoryMethods
{
    public class RepositoryMethods
    {
        private readonly Mock<IRepositoryUnitofWork> _repoTest;
        public RepositoryMethods()
        {
            _repoTest = new Mock<IRepositoryUnitofWork>();
        }


        [Fact]
        public async Task GetBlogListTest()
        {
            //Arrange
            var expectedBlogs = new List<BlogReturnResponseDto>() { new BlogReturnResponseDto() { Id = 1, Name = "Azure News", Url = "www.azure.com", AuthorId = 1 },
            new BlogReturnResponseDto() { Id = 2, Name = "Aws News", Url = "www.aws.com", AuthorId = 2 }};

             _repoTest.Setup(repo => repo.BlogRepository.GetAllBlogs(false, default)).ReturnsAsync(expectedBlogs);

            var repository = _repoTest.Object;

            //Act

            var actualBlogs = await repository.BlogRepository.GetAllBlogs(false,default);

            //Assert

            Assert.Equal(expectedBlogs.Count, actualBlogs.Count());
            Assert.Equal(expectedBlogs[0].Id, actualBlogs.ToList()[0].Id);
        }


        [Fact]
        public async Task GetBlogListByAuthorTestPass()
        {
            // Arrange
            var expectedBlogs = new List<BlogReturnResponseDto>() { new BlogReturnResponseDto() { Id = 1, Name = "Azure News", Url = "www.azure.com", AuthorId = 1 }};

            _repoTest.Setup(repo => repo.BlogRepository.GetAllBlogsByAnAuthor(1,false, default)).ReturnsAsync(expectedBlogs);

            var repository = _repoTest.Object;

            //Act

            var actualBlogs = await repository.BlogRepository.GetAllBlogsByAnAuthor(1,false, default);

            //Assert

            Assert.Equal(expectedBlogs.Count, actualBlogs.Count());
            Assert.Equal(expectedBlogs[0].Id, actualBlogs.ToList()[0].Id);

           
        }

        [Fact]
        public async Task GetBlogListByAuthorTestFail()
        {
            //Arrange
            var expectedBlogs = new List<BlogReturnResponseDto>() { new BlogReturnResponseDto() { Id = 1, Name = "Azure News", Url = "www.azure.com", AuthorId = 1 } };

            _repoTest.Setup(repo => repo.BlogRepository.GetAllBlogsByAnAuthor(1, false, default)).ReturnsAsync(expectedBlogs);

            var repository = _repoTest.Object;

            //Act

            var actualBlogs = await repository.BlogRepository.GetAllBlogsByAnAuthor(2, false, default);

            //Assert

            Assert.NotEqual(expectedBlogs.Count, actualBlogs.Count());


        }

    }
}
