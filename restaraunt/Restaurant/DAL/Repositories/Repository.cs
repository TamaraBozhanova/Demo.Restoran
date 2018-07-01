using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Restaurant.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw new EntityValidationException("Failed to validate entity on Create!");
            }
        }
        public void Update(TEntity item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw new EntityValidationException("Failed to validate entity on Update!");
            }
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
