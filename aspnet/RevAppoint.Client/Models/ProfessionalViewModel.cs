using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Models
{
    public class ProfessionalViewModel
    {
        [Required(AllowEmptyStrings=false)]
        public string Username{get;set;}
        public IEnumerable<Professional> Professionals { get; set; }
        public Professional Professional { get; set; }
        public IEnumerable<Appointment> AppointmentHistory {get;set;}
        public IEnumerable<Appointment> CurrentAppointmets {get;set;}
        public Appointment Appointment {get;set;}
        public ProfessionalViewModel(){}
        public ProfessionalViewModel(UnitOfWork Repo)
        {
            Professionals = Repo.GetAll<Professional>();
        }
    }
}