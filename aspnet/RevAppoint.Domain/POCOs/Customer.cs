using System;
using System.Collections.Generic;

namespace RevAppoint.Domain.POCOs
{
    public class Customer : User
    {
        public Customer()
        {
            this.MemberSince = DateTime.Now;
            this.Type = this.GetType().Name;
        }
        public Customer(string username, string password, string firstName, string lastName, string gender, string phonenumber, string emailaddress)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Type = this.GetType().Name;
            this.MemberSince = DateTime.Now;
            this.Gender = gender;
            this.PhoneNumber = phonenumber;
            this.EmailAddress = emailaddress;


        }

        public Customer(string username, string password, object firstName, object lastName, string gender, string phonenumber, string emailaddress)
        {
            Username = username;
            Password = password;
            Gender = gender;
            PhoneNumber = phonenumber;
            EmailAddress = emailaddress;
        }
    }
}