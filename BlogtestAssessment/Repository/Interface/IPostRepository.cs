using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IPostRepository
    {
        void CreateNewPost(Post post);
        Task<IEnumerable<Post>> GetAllPostInABlog(int blogId,bool trackChanges);

       
    }
}
