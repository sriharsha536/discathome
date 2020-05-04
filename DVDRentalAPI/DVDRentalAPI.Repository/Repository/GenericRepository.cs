using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DVDRentalAPI.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public GenericRepository(DVDRentalContext context)
        {
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression);
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
