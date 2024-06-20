using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogtestAssessment.Repository.Implementations
{
    public class AuthorRepositoryImp : RepositoryBaseImp<Author>, IAuthorRepository
    {

        public AuthorRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public async Task<bool> CheckAuthorExist(string email, bool trackChanges)
        {
            var userCheck = await FindByCondition(au => au.Email.Equals(email), trackChanges).FirstOrDefaultAsync();

            if (userCheck is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckAuthorExistById(int Id, bool trackChanges)
        {
            var userCheck = await FindByCondition(au => au.Id == Id, trackChanges).FirstOrDefaultAsync();

            if (userCheck is null)
            {
                return false;
            }
            return true;
        }

        public void CreateAuthor(Author author)
        {
            Create(author);
        }
    }
}
