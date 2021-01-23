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
        public IEnumerable<Appointment> AppointmentHistory {get;set;}
        public Appointment Appointment {get;set;}
        public string SearchParam {get;set;}
        public CustomerViewModel(){}
        public CustomerViewModel(UnitOfWork Repo)
        {
            Customers = Repo.GetAll<Customer>();
        }
    }
}