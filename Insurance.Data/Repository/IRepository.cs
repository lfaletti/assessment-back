using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Insurance.Data.Repository
{
    /// <summary>
    /// Repository with generic contract.
    /// </summary>
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
