using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class UnitOfWork
    {
        protected readonly RevAppointContext _db;
        private CustomerRepo _CustomerRepo;
        private ProfessionalRepo _ProfessionalRepo;
        private UserRepo _UserRepo;
        
        public UnitOfWork(RevAppointContext _context)
        {
            _db = _context;
        }
        public CustomerRepo CustomerRepo
        {
          get
          {
              if(_CustomerRepo == null)
              {
                _CustomerRepo = new CustomerRepo(_db);
              }
              return _CustomerRepo;
          }
        }
        public ProfessionalRepo ProfessionalRepo
        {
          get
          {
              if(_ProfessionalRepo == null)
              {
                _ProfessionalRepo = new ProfessionalRepo(_db);
              }
              return _ProfessionalRepo;
          }
        }
        public UserRepo UserRepo
        {
          get
          {
              if(_UserRepo == null)
              {
                _UserRepo = new UserRepo(_db);
              }
              return _UserRepo;
          }
        }
         public IList<T> GetAll<T>() where T : class
        {
            return _db.Set<T>().ToList();
        }
        public T GetById<T>(object id) where T : class
        {
            return _db.Set<T>().Find(id);
        }
        public void Insert<T>(T obj) where T : class
        {
            _db.Set<T>().Add(obj);
        }
        public void Update<T>(T obj) where T : class
        {
            _db.Set<T>().Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete<T>(object id) where T : class
        {
            T existing = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(existing);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}