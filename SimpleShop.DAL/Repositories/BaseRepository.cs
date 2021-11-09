using SimpleShop.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.Repositories
{
    /// <summary>
    /// Base repository for CRUD.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Dbset of type T.
        /// </summary>
        protected DbSet<T> dbSet;

        /// <summary>
        /// Book store context.
        /// </summary>
        protected SimpleShopContext simpleShopContext = new SimpleShopContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        public BaseRepository()
        {
            this.dbSet = this.simpleShopContext.Set<T>();
        }

        /// <summary>
        /// Add an entity to context.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void Add(T entity)
        {
            this.simpleShopContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Update an entity in context.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        public void Update(T entity)
        {
            this.simpleShopContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified; // Modified
        }

        /// <summary>
        /// Delete an entity by instance.
        /// </summary>
        /// <param name="entity">An entity instance to be deleted.</param>
        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        /// <summary>
        /// Delete an entity from context by it's Id.
        /// </summary>
        /// <param name="entityId">Id of the entity to be deleted.</param>
        public void Delete(int entityId)
        {
            var currentEntity = this.dbSet.Find(entityId);
            this.Delete(currentEntity);
        }

        /// <summary>
        /// Remove a set of entities.
        /// </summary>
        /// <param name="enties">List of entities to be removed.</param>
        public void RemoveRange(IEnumerable<T> enties)
        {
            this.dbSet.RemoveRange(enties);
        }

        /// <summary>
        /// Find all entities that matched with the given expression.
        /// </summary>
        /// <param name="expression">A lambda expression.</param>
        /// <param name="orderBy">Property to order.</param>
        /// <param name="includeProperties">Eager loading properties.</param>
        /// <returns>List of matched entities.</returns>
        public List<T> FindAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        /// <summary>
        /// Find first entities that matched with the given expression.
        /// </summary>
        /// <param name="expression">A lambda expression.</param>
        /// <param name="orderBy">Property to order.</param>
        /// <param name="includeProperties">Eager loading properties.</param>
        /// <returns>List of matched entities. It there is no matched, return default value.</returns>
        public T FindFirstOrDefault(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Get all entities of type T in the context.
        /// </summary>
        /// <returns>List of all entities of type T.</returns>
        public List<T> GetAll()
        {
            return this.simpleShopContext.Set<T>().ToList();
        }

        /// <summary>
        /// Get pagination.
        /// </summary>
        /// <param name="pageSize">Number of records in a page.</param>
        /// <param name="pageIndex">Index of the page, starting with 0.</param>
        /// <returns>List of elements that inside the given range.</returns>
        public List<T> GetPage(int pageSize, int pageIndex)
        {
            return this.simpleShopContext.Set<T>().Skip(pageSize * pageIndex).Take(pageSize).ToList();
        }

        /// <summary>
        /// Save changes that have been made from last saving.
        /// </summary>
        /// <returns>The number of the state entries written to the database.</returns>
        public int SaveChanges()
        {
            return this.simpleShopContext.SaveChanges();
        }
    }
}
