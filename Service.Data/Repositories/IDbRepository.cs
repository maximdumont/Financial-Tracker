using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Service.Data.Repositories
{
    public interface IDbRepository<T>
    {
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        void Remove(T item);
        bool Contains(T item);
        bool Contains(Func<T, bool> queryFunc);
    }
}