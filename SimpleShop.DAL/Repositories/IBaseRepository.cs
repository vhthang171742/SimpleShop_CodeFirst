using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleShop.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int entityId);
        void Delete(T entity);
        List<T> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        T FindFirstOrDefault(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        List<T> GetAll();
        List<T> GetPage(int pageSize, int pageIndex);
        void RemoveRange(IEnumerable<T> enties);
        int SaveChanges();
        void Update(T entity);
    }
}