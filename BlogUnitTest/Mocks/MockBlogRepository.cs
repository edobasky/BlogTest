using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUnitTest.Mocks
{
    public class MockBlogRepository
    {
        public static Mock<IRepositoryUnitofWork> unitOfWorkMockRepo()
        {
            var blogTypes = new List<BlogReturnResponseDto>
            {
               new BlogReturnResponseDto
               {
                   Id = 1,
                   Name = "Test",
                   Url = "web",
                   AuthorId = 1,
               },
               new BlogReturnResponseDto
               {
                   Id= 2,
                   Name= "Test2",
                   Url = "web2",
                   AuthorId = 1,
               },
                new BlogReturnResponseDto
               {
                   Id= 3,
                   Name= "Test3",
                   Url = "web23",
                   AuthorId = 1,
               }
            };

          

            int AuthorId = 5;

            var mockRepository = new Mock<IRepositoryUnitofWork>();
            bool trackChanges = false;
            bool isExist = true;
            int successfulSave = 1;
            int failedSave = 0;

            mockRepository.Setup(r => r.BlogRepository.GetAllBlogs(trackChanges,default)).ReturnsAsync(blogTypes);

            mockRepository.Setup(r => r.BlogRepository.CreateNewBlog(It.IsAny<Blog>()));

            mockRepository.Setup(r => r.BlogRepository.GetAllBlogsByAnAuthor(AuthorId, trackChanges, default)).ReturnsAsync(blogTypes);

            mockRepository.Setup(r => r.AuthorRepository.CheckAuthorExistById(It.IsAny<int>(), trackChanges)).ReturnsAsync(isExist);

            mockRepository.Setup(r => r.SaveAsync()).ReturnsAsync(successfulSave);

            return mockRepository;
        }
    }
}
