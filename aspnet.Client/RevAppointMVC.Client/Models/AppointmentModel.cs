using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class AppointmentModel : EntityModel
    {
        public TimeModel Time { get; set; }
        public ProfessionalModel Professional { get; set; }
        public UserModel Client { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsFufilled { get; set; }
    }
}