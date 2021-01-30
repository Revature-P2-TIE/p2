using System.ComponentModel.DataAnnotations;

namespace RevAppoint.Client.Models
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings=false)]
        public string Username{get;set;}

        [Required(AllowEmptyStrings=false)]
        public string Password{get;set;}

        public string Error{get;set;}
    }
}