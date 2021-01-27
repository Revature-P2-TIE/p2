using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Appointment> GetAppointments(long id)
        {
            return _db.Appointments.Where(x=>x.Client.EntityID == id).Include(x=>x.Professional).Include(x=>x.Time);
        }
        public IEnumerable<Appointment> GetAppointments(string username)
        {
            return _db.Appointments.Where(x=>x.Client.Username == username).Include(x=>x.Professional).Include(x=>x.Time);
        }

        public void AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
    }
}