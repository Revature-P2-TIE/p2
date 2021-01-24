using System;
using System.Collections.Generic;
using RevAppoint.Domain.POCOs;

namespace RevAppoint.Client.Models
{
    public class AppointmentViewModel
    {
        public List<Appointment> Appointments { get; set; }
        public string StartTime { get; set; }
        public Professional Professional { get; set;}
        public string ProfessionalUsername{get;set;}
        public Customer Customer { get; set;}  
        public string CustomerUsername {get;set;}
        public DateTime Time { get; set; }    

    }
}