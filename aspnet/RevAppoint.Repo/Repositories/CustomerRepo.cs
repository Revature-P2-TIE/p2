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

        public IEnumerable<Appointment> GetAppointmentsAccepted(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Client.Username == username)
                        .Where(x => x.IsAccepted == true)
                        .Where(x =>x.IsFufilled == false)
                        .Include(x=>x.Professional)
                        .Include(x=>x.Time);
        }

        public IEnumerable<Appointment> GetAppointmentsFufilled(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Client.Username == username)
                        .Where(x => x.IsAccepted == true)
                        .Where(x =>x.IsFufilled == true)
                        .Include(x=>x.Professional)
                        .Include(x=>x.Time);
        }

        public IEnumerable<Appointment> GetAppointmentsPending(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Client.Username == username)
                        .Where(x => x.IsAccepted == false)
                        .Where(x =>x.IsFufilled == false)
                        .Include(x=>x.Professional)
                        .Include(x=>x.Time);
        }

        public bool AddCustomer(Customer customer)
        {
              IEnumerable<Customer> list = _db.Customers.Where(x => x.Username == customer.Username);     
             
             if(list.Count() < 1) 
             {
                 _db.Customers.Add(customer);
                 _db.SaveChanges();
                 return true;
             }
             
             return false;
 
        }
    }
}