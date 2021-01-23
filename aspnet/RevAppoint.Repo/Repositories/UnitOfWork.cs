using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class UnitOfWork
    {
        protected readonly RevAppointContext _db;
        private UserRepo _UserRepo;
        
        public UnitOfWork(RevAppointContext _context)
        {
            _db = _context;
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

    }
}