using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IBlogRepository
    {
        void CreateNewBlog(Blog blog);

        Task<bool> CheckBlogExist(int blogId, bool trackChanges);
        Task<IEnumerable<BlogReturnResponseDto>> GetAllBlogsByAnAuthor(int AuthorId, bool trackChanges, CancellationToken cancellation);

        Task<IEnumerable<BlogReturnResponseDto>> GetAllBlogs(bool trackChanges, CancellationToken cancellation);

    }
}
