using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using RevAppoint.Domain.POCOs;

namespace RevAppoint.Client.Models
{
    public class AppointmentViewModel : ValidationAttribute
    {
        public List<Appointment> Appointments { get; set; }
        [AppointmentViewModel,Required]
        public string StartTime { get; set; }
        public Professional Professional { get; set;}
        public string ProfessionalUsername{get;set;}
        public Customer Customer { get; set;}  
        public string CustomerUsername {get;set;}
        public DateTime Time { get; set; }    

        public AppointmentViewModel(){}
        public override bool IsValid(object value)
        {
            if(value == null)
            {
             return false;   
            }
            else
            {
                string format = "MM/dd/yyyy h:mm tt";
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime startTime = DateTime.ParseExact((string)value, format, provider);
                
                if(startTime < DateTime.Now)
                { 
                    return false; 
                }

                return true;
            }
        }
    }
}