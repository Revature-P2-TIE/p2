using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RevAppoint.Client.Models
{
    public class AppointmentViewModel : ValidationAttribute
    {
        public List<AppointmentModel> Appointments { get; set; }
        [AppointmentViewModel]
        public string StartTime { get; set; }
        public ProfessionalModel Professional { get; set;}
        public string ProfessionalUsername{get;set;}
        public CustomerModel Customer { get; set;}  
        public string CustomerUsername {get;set;}
        public DateTime Time { get; set; }    
        public string AppointmentID {get;set;}
        public bool IsFufilled { get; set; }
        public bool IsAccepted { get; set; }
        public string HourlyRate {get; set;}
        public string AppointmentLengthInHours{get;set;}

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string format = "MM/dd/yyyy h:mm tt";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime startTime = DateTime.ParseExact(value.ToString().Trim(), format, provider);

            if(startTime < DateTime.Now)
            {
                return false;
            }
            else{
                return true;
            }
    }
  }
}
