using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IBlogRepository
    {
        void CreateNewBlog(Blog blog, int AuthoId);

        Task<IEnumerable<Blog>> GetAllBlogsByAnAuthor(int AuthorId, bool trackChanges);
    }
}
