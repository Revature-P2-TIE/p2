using System.Collections.Generic;
using System.Linq;
using RevAppoint.Domain.POCOs;
using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class ProfessionalRepo
    {
        private RevAppointContext _db;

        public ProfessionalRepo(RevAppointContext _context)
        {
            _db = _context;
        }
        public Professional GetProfessional(string Username)
        {
            return _db.Professionals.SingleOrDefault(s => s.Username == Username);
        }
    }
}