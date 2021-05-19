using System;
using System.Linq;
using System.Linq.Expressions;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
