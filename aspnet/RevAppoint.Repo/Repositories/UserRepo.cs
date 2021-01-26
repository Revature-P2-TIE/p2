using System.Collections.Generic;
using System.Linq;
using RevAppoint.Domain.POCOs;
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

        public User GetUser(string Username, string Password)
        {
            return _db.Users.FirstOrDefault(x => (x.Username.Equals(Username) && x.Password.Equals(Password)));
        }
    }
}