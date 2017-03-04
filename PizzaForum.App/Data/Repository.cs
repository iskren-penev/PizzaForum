namespace PizzaForum.App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using PizzaForum.App.Interfaces;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> set;

        public Repository(DbSet<TEntity> set)
        {
            this.set = set;
        }
        public void Add(TEntity entity)
        {
            this.set.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.set.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.set;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public TEntity FindById(int id)
        {
            return this.set.Find(id);
        }

        public TEntity FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.FirstOrDefault(predicate);
        }

        public int Count()
        {
            return this.set.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Count(predicate);
        }
        
    }
}
