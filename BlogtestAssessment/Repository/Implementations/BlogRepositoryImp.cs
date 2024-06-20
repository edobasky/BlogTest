using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogtestAssessment.Repository.Implementations
{
    public class BlogRepositoryImp : RepositoryBaseImp<Blog>, IBlogRepository
    {
        public BlogRepositoryImp(BlogDBContext blogDBContext) : base(blogDBContext)
        {
        }

        public async Task<bool> CheckBlogExist(int blogId, bool trackChanges)
        {
            var blogCheckResult = await FindByCondition(bg => bg.Id == blogId, trackChanges).FirstOrDefaultAsync();

            return blogCheckResult == null ? false : true;
        }

        public void CreateNewBlog(Blog blog)
        {
            Create(blog);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsByAnAuthor(int AuthorId, bool trackChanges) =>
            await FindByCondition(bg => bg.AuthorId == AuthorId, trackChanges)
            .ToListAsync();
    }
}
