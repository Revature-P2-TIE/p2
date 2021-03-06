using System;
using System.Collections.Generic;

namespace RevAppoint.Client.Models
{
    public class UserModel : EntityModel
    {
        public string Username { get; set; }
        public string Password {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type {get; set;}
        public string Gender {get;set;}
        public string PhoneNumber {get;set;}
        public string EmailAddress {get;set;}
        public DateTime MemberSince {get;set;}
        public List<AppointmentModel> Appointments { get; set; }
    }
}