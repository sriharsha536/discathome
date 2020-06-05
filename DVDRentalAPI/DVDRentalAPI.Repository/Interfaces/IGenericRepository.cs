using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int? id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entity);
    }
}
