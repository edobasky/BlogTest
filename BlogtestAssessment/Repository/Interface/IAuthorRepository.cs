using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;

namespace BlogtestAssessment.Repository.Interface
{
    public interface IAuthorRepository
    {
        void CreateAuthor(Author author);

        Task<bool> CheckAuthorExist(string email, bool trackChanges);

        Task<bool> CheckAuthorExistById(int Id, bool trackChanges);

        Task<IEnumerable<AuthorReturnDto>> GetAllAuthors(bool trackChanges, CancellationToken cancellationToken);
    }
}
