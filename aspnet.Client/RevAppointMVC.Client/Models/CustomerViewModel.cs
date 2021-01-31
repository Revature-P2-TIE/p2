using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class CustomerViewModel
    {
        [Required(AllowEmptyStrings=false)]
        public string Username{get;set;}
        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<ProfessionalModel> Professionals { get; set; }
        public CustomerModel Customer { get; set; }
        public IEnumerable<AppointmentModel> AppointmentHistory {get;set;}
        public AppointmentModel Appointment {get;set;}
        public string SearchParam {get;set;}
        public string ProfessionalSearchValue {get;set;}
        public IEnumerable<ProfessionalModel> ListOfProfessionals {get;set;}
        public string SearchedProfessionalsUsername {get;set;}
        public ProfessionalModel Professional {get;set;}
        public string HourlyRate{get;set;}
        public string AppointmentLengthInHours{get;set;}
 /*       public CustomerViewModel(){}
        public CustomerViewModel(UnitOfWork Repo)
        {
            Customers = Repo.GetAll<Customer>();
            AppointmentHistory = Repo.GetAll<Appointment>();
        }*/
    }
}