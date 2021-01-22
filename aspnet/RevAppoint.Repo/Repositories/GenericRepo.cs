using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class GenericRepo<T> where T : class
    {
        private RevAppointContext _context;
        
        private DbSet<T> table;

        public GenericRepo()
        {
            this._context = new RevAppointContext();
            table = _context.Set<T>();
        }
        public GenericRepo(RevAppointContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}