using Sirius.Data.Context;
using Sirius.Data.Repository.Abstract;
using Sirius.Data.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected SiriusContext dbContext;
        protected readonly IDbSet<T> _dbset;

        public BaseRepository(SiriusContext context)
        {
            dbContext = context;
            _dbset = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable<T>();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public virtual async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _dbset.Where(predicate));
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AnyAsync(predicate);
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Edit(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        //public virtual async Task AddAsync(T entity)
        //{
        //    _dbset.Add(entity);
        //    await dbContext.SaveChangesAsync();
        //}

        //public virtual async Task EditAsync(T entity)
        //{
        //    dbContext.Entry(entity).State = EntityState.Modified;
        //    await dbContext.SaveChangesAsync();
        //}

        //public virtual async Task DeleteAsync(T entity)
        //{
        //    _dbset.Remove(entity);
        //    await dbContext.SaveChangesAsync();
        //}

        //public static IQueryable<T> IncludeMultiple(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));
        //    }
        //    return query;
        //}
    }
}
