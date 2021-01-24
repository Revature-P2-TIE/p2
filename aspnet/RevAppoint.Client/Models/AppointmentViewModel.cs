using RevAppoint.Domain.POCOs;

namespace RevAppoint.Client.Models
{
    public class AppointmentViewModel
    {
        Customer Customer {get;set;}
        Professional Professional{get;set;}
        Appointment Appointment{get;set;}

    }
}