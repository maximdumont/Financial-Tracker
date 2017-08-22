using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Service.Data.Contexts;

namespace Service.Data.Repositories
{
    public abstract class BaseRepository<T> : IDbRepository<T> where T : class
    {
        protected BaseRepository(DbFinContext context)
        {
            Context = context;
        }

        public DbFinContext Context { get; }

        public void Add(T item)
        {
            using (var context = new DbFinContext())
            {
                context.Set<T>().Add(item);
                context.SaveChanges();
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            using (var context = new DbFinContext())
            {
                context.Set<T>().AddRange(items);
                context.SaveChanges();
            }
        }

        public void Remove(T item)
        {
            using (var context = new DbFinContext())
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }

        public bool Contains(T item)
        {
            return Context.Set<T>().Contains(item);
        }

        public bool Contains(Func<T, bool> queryFunc)
        {
            return (Context?.Set<T>()).Any(queryFunc);
        }

        public DbSet<T> GetSet()
        {
            using (var context = new DbFinContext())
            {
                return context.Set<T>();
            }
        }
    }
}