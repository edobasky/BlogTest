using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogtestAssessment.Repository.Implementations
{
    public class PostRepositoryImp : RepositoryBaseImp<Post>, IPostRepository
    {
        public PostRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public void CreateNewPost(Post post, int BlogId)
        {
            post.BlogId = BlogId;
            Create(post);
        }

        public async Task<IEnumerable<Post>> GetAllPostInABlog(int blogId, bool trackChanges) => 
            await FindByCondition(pst => pst.BlogId == blogId,trackChanges)
            .ToListAsync();
    }
}
