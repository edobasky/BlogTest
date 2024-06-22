using BlogtestAssessment.Data;
using BlogtestAssessment.Models.Dto;
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


        public async Task<IEnumerable<BlogReturnResponseDto>> GetAllBlogs(bool trackChanges, CancellationToken cancellation) => 
            await FindAll(trackChanges).Select(bg => new BlogReturnResponseDto()
            {
                Id = bg.Id,
                Name = bg.Name,
                Url = bg.Url
            }) .ToListAsync(); 

        public async Task<IEnumerable<BlogReturnResponseDto>> GetAllBlogsByAnAuthor(int Id, bool trackChanges, CancellationToken cancellation) =>
            await FindByCondition(bg => bg.AuthorId == Id, trackChanges).Select(bg => new BlogReturnResponseDto()
            {
                Id = bg.Id,
                Name = bg.Name,
                Url = bg.Url,
                AuthorId = bg.AuthorId
            })
            .ToListAsync(cancellation);
    }
}
