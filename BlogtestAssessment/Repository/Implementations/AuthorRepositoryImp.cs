using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;

namespace BlogtestAssessment.Repository.Implementations
{
    public class AuthorRepositoryImp : RepositoryBaseImp<Author>, IAuthorRepository
    {
        public AuthorRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public void CreateewAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
