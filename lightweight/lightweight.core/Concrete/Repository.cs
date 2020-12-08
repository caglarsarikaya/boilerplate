using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using lightweight.core.Abstract;
using lightweight.data.Context;
using Microsoft.EntityFrameworkCore;

namespace lightweight.core.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext _context;
        public DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
          await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }


        //public virtual T GetById(object id)
        //{
        //    return Entities.Find(id);
        //}

        ///// <summary>
        /////     Insert entity
        ///// </summary>
        ///// <param name="entity">Entity</param>
        //public void Insert(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));
        //    _entities.Add(entity);
        //    _context.SaveChanges();
        //}

        ///// <summary>
        /////     Insert entities
        ///// </summary>
        ///// <param name="entities">Entities</param>
        //public virtual void Insert(IEnumerable<T> entities)
        //{
        //    if (entities == null)
        //        throw new ArgumentNullException(nameof(entities));

        //    foreach (var entity in entities)
        //        Entities.Add(entity);

        //    _context.SaveChanges();
        //}

        ///// <summary>
        /////     Update entity
        ///// </summary>
        ///// <param name="entity">Entity</param>
        //public void Update(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));
        //    _context.SaveChanges();
        //}


        ///// <summary>
        /////     Update entities
        ///// </summary>
        ///// <param name="entities">Entities</param>
        //public virtual void Update(IEnumerable<T> entities)
        //{
        //    if (entities == null)
        //        throw new ArgumentNullException(nameof(entities));

        //    _context.SaveChanges();
        //}

        ///// <summary>
        /////     Delete entity
        ///// </summary>
        ///// <param name="entity">Entity</param>
        //public void Delete(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));
        //    Entities.Remove(entity);
        //    _context.SaveChanges();
        //}

        ///// <summary>
        /////     Delete entities
        ///// </summary>
        ///// <param name="entities">Entities</param>
        //public virtual void Delete(IEnumerable<T> entities)
        //{
        //    if (entities == null)
        //        throw new ArgumentNullException(nameof(entities));

        //    foreach (var entity in entities)
        //        Entities.Remove(entity);
        //    _context.SaveChanges();
        //}

        //public IQueryable<T> IncludeMany(params Expression<Func<T, object>>[] includes)
        //{
        //    return _entities.IncludeMultiple(includes);
        //}

        //public IEnumerable<T> GetSql(string sql)
        //{
        //    return Entities.FromSql(sql);
        //}

        ///// <summary>
        /////     Gets a table
        ///// </summary>
        //public virtual IQueryable<T> Table => Entities;

        ///// <summary>
        /////     Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only
        /////     operations
        ///// </summary>
        //public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        ///// <summary>
        /////     Entities
        ///// </summary>
        //protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}