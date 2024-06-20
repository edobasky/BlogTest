using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;

namespace BlogtestAssessment.Repository.Implementations
{
    public class PostRepositoryImp : RepositoryBaseImp<Post>, IPostRepository
    {
        public PostRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public void CreateNewPost(Post post, int BlogId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllPostInABlog(int blogId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
