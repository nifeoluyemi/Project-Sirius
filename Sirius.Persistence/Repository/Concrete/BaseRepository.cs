using Sirius.Persistence.Context;
using Sirius.Persistence.Repository.Abstract;
using Sirius.Persistence.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Repository.Concrete
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

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
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
    }
}
