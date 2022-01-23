using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPIExample.Data.Repositories.Base
{
    public class Repository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public TEntity Get(int id) 
            => _entities.Find(id);

        public  IEnumerable<TEntity> GetAll()
            =>  _entities.ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _entities.Where(predicate);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
            => _entities.SingleOrDefault(predicate);

        public void Add(TEntity entity)
            => _entities.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) 
            => _entities.AddRange(entities);

        public void Remove(TEntity entity) 
            => _entities.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) 
            => _entities.RemoveRange(entities);

        public void Update(TEntity entity) 
            => _entities.Update(entity);
    }
}
