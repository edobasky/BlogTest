using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;

namespace BlogtestAssessment.Repository.Implementations
{
    public class BlogRepositoryImp : RepositoryBaseImp<Blog>, IBlogRepository
    {
        public BlogRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public void CreateNewBlog(Blog blog, int AuthoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blog>> GetAllBlogsByAnAuthor(int AuthorId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
