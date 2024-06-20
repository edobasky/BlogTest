using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IAuthorRepository
    {
        void CreateAuthor(Author author);

        Task<bool> CheckAuthorExist(string email, bool trackChanges);
    }
}
