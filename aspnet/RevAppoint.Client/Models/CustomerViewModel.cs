using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Models
{
    public class CustomerViewModel
    {
        [Required(AllowEmptyStrings=false)]
        public string Username{get;set;}
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Professional> Professionals { get; set; }
        public IEnumerable<Appointment> AppointmentHistory {get;set;}
        public IEnumerable<Appointment> CurrentAppointments { get; set; }
        public Appointment Appointment {get;set;}
        public string SearchParam {get;set;}
        public string ProfessionalSearchValue {get;set;}
        public IEnumerable<Professional> ListOfProfessionals {get;set;}
        public string SearchedProfessionalsUsername {get;set;}
        public Professional Professional {get;set;}
        public CustomerViewModel(){}
        public CustomerViewModel(UnitOfWork Repo)
        {
            Customers = Repo.GetAll<Customer>();
            AppointmentHistory = Repo.GetAll<Appointment>();
        }
    }
}