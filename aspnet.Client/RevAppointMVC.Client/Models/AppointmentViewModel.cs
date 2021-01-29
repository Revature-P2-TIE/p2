using System;
using System.Collections.Generic;

namespace RevAppoint.Client.Models
{
    public class AppointmentViewModel
    {
        public List<AppointmentModel> Appointments { get; set; }
        public string StartTime { get; set; }
        public ProfessionalModel Professional { get; set;}
        public string ProfessionalUsername{get;set;}
        public CustomerModel Customer { get; set;}  
        public string CustomerUsername {get;set;}
        public DateTime Time { get; set; }    

    }
}