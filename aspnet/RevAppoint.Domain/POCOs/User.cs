using System.Collections.Generic;

namespace RevAppoint.Domain.POCOs
{
    public class User : AEntityID
    {
        public string Username { get; set; }
        public string Password {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Appointment> Appointments { get; set; }

        public User(){}
        public User(string username, string password, string firstName, string lastName)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Appointments = new List<Appointment>();
        }
    }
}