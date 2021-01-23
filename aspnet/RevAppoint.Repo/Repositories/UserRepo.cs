using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class UserRepo
    {
        private RevAppointContext _db;

        public UserRepo(RevAppointContext _context)
        {
            _db = _context;
        }
    }
}