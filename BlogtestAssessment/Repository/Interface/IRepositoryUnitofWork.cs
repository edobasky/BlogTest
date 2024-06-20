namespace BlogtestAssessment.Repository.Interface
{
    public interface IRepositoryUnitofWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBlogRepository BlogRepository { get; }
        IPostRepository PostRepository { get; }

        Task<int> SaveAsync();
    }
}
