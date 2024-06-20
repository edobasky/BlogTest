using BlogtestAssessment.Data;
using BlogtestAssessment.Repository.Interface;

namespace BlogtestAssessment.Repository.Implementations
{
    public class RepositoryUnitofWork : IRepositoryUnitofWork
    {
        private readonly BlogDBContext _dBContext;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<IBlogRepository> _blogRepository;

        public RepositoryUnitofWork(BlogDBContext dBContext)
        {
            _dBContext = dBContext;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepositoryImp(dBContext));
            _blogRepository = new Lazy<IBlogRepository>(() => new 
            BlogRepositoryImp(dBContext));
            _postRepository = new Lazy<IPostRepository>(() => new
            PostRepositoryImp(dBContext));

        }

        public IAuthorRepository AuthorRepository => _authorRepository.Value;

        public IBlogRepository BlogRepository => _blogRepository.Value;

        public IPostRepository PostRepository => _postRepository.Value;

        public async Task<int> SaveAsync() => await _dBContext.SaveChangesAsync();
    }
}
