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
    public class MockAuthorRepository
    {
        public static Mock<IRepositoryUnitofWork> unitOfWorkMockRepo()
        {

            var mockRepository = new Mock<IRepositoryUnitofWork>();
            bool trackChanges = true;
            bool isExist = false;
            int successfulSave = 1;
            int failedSave = 0;

            mockRepository.Setup(r => r.AuthorRepository.CreateAuthor(It.IsAny<Author>()));

            mockRepository.Setup(r => r.SaveAsync()).ReturnsAsync(successfulSave);

            mockRepository.Setup(r => r.AuthorRepository.CheckAuthorExist(It.IsAny<string>(),trackChanges)).ReturnsAsync(isExist);

            return mockRepository;
        }
    }
}
