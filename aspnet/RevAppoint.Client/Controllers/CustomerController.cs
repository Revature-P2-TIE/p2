using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private UnitOfWork Repo;
        public CustomerController(UnitOfWork repo)
        {
            Repo = repo;
        }

        [HttpGet("/Customer")]
        public IActionResult GetUser()
        {
            return View("Login", new CustomerViewModel(Repo));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectUser(CustomerViewModel customer)
        {
 
            if(ModelState.IsValid)
            {
                customer.Customer = Repo.CustomerRepo.GetCustomer(customer.Username);
                // customer.AppointmentHistory = Repo.AppointmentRepo.GetAppointmentByUser(customer.User);
                return View("UserHome", customer);
            }
            //TODO ADD LOGIC TO CHECH IF THEY ARE A PROFESSIONAL
            else
            {
                customer.Customers = Repo.GetAll<Customer>();
                return View("Login", customer);
            }
        }

        [HttpPost("/Display")]
        public IActionResult DisplayProfessionals(CustomerViewModel model)
        {
            return View("DisplayProfessionals", model);
        }
        [HttpGet("/SearchForProfessionals/{id}")]
        public IActionResult SearchForProfessionals(string id)
        {
           CustomerViewModel customer = new CustomerViewModel();
           customer.Customer = Repo.CustomerRepo.GetCustomer(id);
           customer.Username = customer.Customer.Username;
           return View("SearchForProfessional", customer);
        }
        [HttpGet("/AppointmentHistory/{id}")]
        public IActionResult AppointmentHistory(string customerUsername)
        {
            if(customerUsername != null)
            {
                AppointmentViewModel appointment = new AppointmentViewModel();
                appointment.Appointments = Repo.CustomerRepo.GetAppointments(customerUsername).ToList();
                return View("UserHistory",appointment);

            }
            else
            {
                return RedirectToAction("GetUser");
            }

        }
        [HttpGet("/CurrentAppointments/{id}")]
        public IActionResult CurrentAppointments(string id)
        {
           CustomerViewModel customer = new CustomerViewModel();
           customer.Customer = Repo.CustomerRepo.GetCustomer(id);
            customer.Username = customer.Customer.Username;
            return View("CurrentAppointment", customer);
        }

    }
}