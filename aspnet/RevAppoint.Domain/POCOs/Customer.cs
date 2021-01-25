using System.Collections.Generic;

namespace RevAppoint.Domain.POCOs
{
    public class Customer : User
    {
        public Customer(){}
        public Customer(string username, string password, string firstName, string lastName)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Type = this.GetType().Name;
        }

      //  public void CreateAppointment(Time start, Time Finish, Professional professional)
     //   {

     //   }

      //  public void CheckIfTimeIsBetween(Time availablility, Time startTime)
    }
}