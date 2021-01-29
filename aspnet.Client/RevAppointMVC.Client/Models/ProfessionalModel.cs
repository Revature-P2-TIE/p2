using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class ProfessionalModel : UserModel
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public TimeModel AvailableTime { get; set; }
        public int AppointmentLengthInHours {get;set;}
        public decimal HourlyRate {get;set;}
        public string Language {get;set;}
        public string Bio {get;set;}
        public double Rating {get;set;}
    }
}