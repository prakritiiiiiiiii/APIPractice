using Microsoft.EntityFrameworkCore;
using StudentWebApi.Data.Repositories.Interface;
using System;

namespace StudentWebApi.Data.Repositories.Implementation
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly ApplicationDbContext _context;
        private bool _disposed = false;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }
        public int InsertRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return _context.SaveChanges();
        }
        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }
        public int DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return _context.SaveChanges();
        }
        public int Count()
        {
            return _context.Set<T>().Count();
        }
        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public T? Find(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<T?> FindAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public IEnumerable<T> GetEnumerable()
        {
            return _context.Set<T>().AsEnumerable();
        }
        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

    }
}
