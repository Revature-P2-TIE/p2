using System.Collections.Generic;
using System.Linq;
using RevAppoint.Domain.POCOs;
using RevAppoint.Storage;

namespace RevAppoint.Repo.Repositories
{
    public class CustomerRepo
    {
        private RevAppointContext _db;

        public CustomerRepo(RevAppointContext _context)
        {
            _db = _context;
        }
        public Customer GetCustomer(string Username)
        {
            return _db.Customers.SingleOrDefault(s => s.Username == Username);
        }
    }
}