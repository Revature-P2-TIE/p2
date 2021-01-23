using System.Collections.Generic;

namespace RevAppoint.Domain.POCOs
{
    public abstract class User : AEntityID
    {
        public string Username { get; set; }
        public string Password {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}