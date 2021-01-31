using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Professional> GetProfessionals()
        {
            return _db.Professionals;
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
        public IEnumerable<Appointment> GetAppointments(long id)
        {
            return _db.Appointments.Where(x=>x.Professional.EntityID == id).Include(x=>x.Time);
        }

        public IEnumerable<Appointment> GetAppointments(string username)
        {
            return _db.Appointments.Where(x=>x.Professional.Username == username).Include(x=>x.Time);
        }

        public bool AddProfessional(Professional professional)
        {
              IEnumerable<Professional> list = _db.Professionals.Where(x => x.Username == professional.Username);     
             
             if(list.Count() < 1) 
             {
                 _db.Professionals.Add(professional);
                 _db.SaveChanges();
                 return true;
             }
             
             return false;
        }

        public IEnumerable<Appointment> GetAppointmentsAccepted(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Professional.Username == username)
                        .Where(x => x.IsAccepted == true)
                        .Where(x =>x.IsFufilled == false)
                        .Include(x=>x.Time);
        }
        public IEnumerable<Appointment> GetAppointmentsFufilled(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Professional.Username == username)
                        .Where(x => x.IsAccepted == true)
                        .Where(x =>x.IsFufilled == true)
                        .Include(x=>x.Time);
        }
        public IEnumerable<Appointment> GetAppointmentsPending(string username)
        {
            return _db.Appointments
                        .Where(x=>x.Professional.Username == username)
                        .Where(x => x.IsAccepted == false)
                        .Where(x =>x.IsFufilled == false)
                        .Include(x=>x.Time);

        }
    }
}