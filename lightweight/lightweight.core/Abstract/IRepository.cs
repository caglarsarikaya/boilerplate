using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lightweight.core.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity); 
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);

        //IQueryable<T> Table { get; }
        //IQueryable<T> TableNoTracking { get; }
        //T GetById(object id);
        //void Insert(T entity);
        //void Insert(IEnumerable<T> entities);
        //void Update(T entity);
        //void Update(IEnumerable<T> entities);
        //void Delete(T entity);
        //void Delete(IEnumerable<T> entities);
        //IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes);
        //IEnumerable<T> GetSql(string sql);
    }
}