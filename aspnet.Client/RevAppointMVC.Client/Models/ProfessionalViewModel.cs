using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class ProfessionalViewModel
    {
        [Required(AllowEmptyStrings=false)]
        public string Username{get;set;}
        public IEnumerable<ProfessionalModel> Professionals { get; set; }
        public ProfessionalModel Professional { get; set; }
        public IEnumerable<AppointmentModel> AppointmentHistory {get;set;}
        public IEnumerable<AppointmentModel> CurrentAppointmets {get;set;}
        public AppointmentModel Appointment {get;set;}
 /*       public ProfessionalViewModel(){}
        public ProfessionalViewModel(UnitOfWork Repo)
        {
            Professionals = Repo.GetAll<Professional>();
        }*/

    }
}