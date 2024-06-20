using BlogtestAssessment.Data;
using BlogtestAssessment.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogtestAssessment.Repository.Implementations
{
    public abstract class RepositoryBaseImp<T> : IRepositoryBase<T> where T : class
    {
        private readonly BlogDBContext _blogDBContext;

        protected RepositoryBaseImp(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public void Create(T entity) => 
            _blogDBContext.Add(entity);

        public void Delete(T entity) =>
            _blogDBContext.Remove(entity);
            

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            _blogDBContext.Set<T>()
            .AsNoTracking() :
            _blogDBContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _blogDBContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            _blogDBContext.Set<T>()
            .Where(expression);

        public void Update(T entity) =>
            _blogDBContext.Update(entity);
    }
}
