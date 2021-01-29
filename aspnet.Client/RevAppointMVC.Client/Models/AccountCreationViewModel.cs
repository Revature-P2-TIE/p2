using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class AccountCreationViewModel
    {
        public string username {get;set;}
        public string password {get;set;}
        public string firstname {get;set;}
        public string lastname {get;set;}
        public string gender {get;set;}
        public string phonenumber {get;set;}
        public string emailaddress {get;set;}

    }
}