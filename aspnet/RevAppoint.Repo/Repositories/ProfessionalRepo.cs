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

        public IEnumerable<Professional> SearchForProfessionals(string SearchParam, string SearchValue)
        {
            List<Professional> returnList = new List<Professional>();
            
            if(SearchParam.Equals("title"))
            {
                return _db.Professionals.Where(p => p.Title == SearchValue);
            }
            if(SearchParam.Equals("name"))
            {
                 return _db.Professionals.Where(p => p.LastName == SearchValue);
            }
            if(SearchParam.Equals("location"))
            {
                 return _db.Professionals.Where(p => p.Location == SearchValue);
            }
            return returnList;
        }
    }
}