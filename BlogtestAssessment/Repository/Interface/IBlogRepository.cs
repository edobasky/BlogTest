using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IBlogRepository
    {
        void CreateNewBlog(Blog blog);

        Task<bool> CheckBlogExist(int blogId, bool trackChanges);
        Task<IEnumerable<Blog>> GetAllBlogsByAnAuthor(int AuthorId, bool trackChanges);

    }
}
