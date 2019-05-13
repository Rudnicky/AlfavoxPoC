using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Alfavox.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AlfavoxDbContext _context;

        public Repository(AlfavoxDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
