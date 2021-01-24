using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class CustomerController : Controller
    {
        private UnitOfWork Repo;
        public CustomerController(UnitOfWork repo)
        {
            Repo = repo;
        }

        [HttpGet("/Customer")]
        [Route("")]
        public IActionResult GetUser()
        {
            return View("Login", new CustomerViewModel(Repo));
        }

        [HttpPost("/Home")]
        [ValidateAntiForgeryToken]
        public IActionResult SelectUser(CustomerViewModel customer)
        {
            if(ModelState.IsValid)
            {
                customer.Customer = Repo.CustomerRepo.GetCustomer(customer.Username);
                return View("UserHome", customer);
            }
            else
            {
                customer.Customers = Repo.GetAll<Customer>();
                return View("Login", customer);
            }
        }

        [HttpGet("/Home/{username}")]
        public IActionResult Home(string username)
        {
            var CustomerViewModel = new CustomerViewModel();
            CustomerViewModel.Username = username;
            CustomerViewModel.Customer = Repo.CustomerRepo.GetCustomer(username);
            return View("UserHome", CustomerViewModel);    
        }

        [HttpGet("/Professionals/{id}")]
        public IActionResult DisplayProfessionals(string id)
        {
            if(id != null)
            {
                var professional = new ProfessionalViewModel(Repo);
                ViewBag.Customer = id;
                return View("DisplayProfessionals", professional);
            }
            else
            {
                return RedirectToAction("GetUser");
            }
        }

        [HttpGet("/History/{id}")]
        public IActionResult AppointmentHistory(string id)
        {
            AppointmentViewModel appointment = new AppointmentViewModel();
            var Customer = Repo.CustomerRepo.GetCustomer(id);
            appointment.Appointments = Repo.CustomerRepo.GetAppointments(Customer.EntityID).ToList();
            return View("UserHistory",appointment);
        }

        [HttpPost("/SelectTime")]
        public IActionResult SelectTime(string id,string profid)
        {
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Professional = Repo.ProfessionalRepo.GetProfessional(profid);
            appointment.Customer = Repo.CustomerRepo.GetCustomer(id);

            return View("SelectTime", appointment);
        }

        [HttpPost("/SetAppointment")]
        public IActionResult SetAppointment(string id, string profid, AppointmentViewModel model)
        {
            string format = "MM/dd/yyyy h:mm tt";
            CultureInfo provider = CultureInfo.InvariantCulture;

            Appointment appointment = new Appointment();
            appointment.Client = Repo.CustomerRepo.GetCustomer(id); 
            var professional = appointment.Professional = Repo.ProfessionalRepo.GetProfessional(profid);

            try 
            {
                DateTime startTime = DateTime.ParseExact(model.StartTime.Trim(), format, provider);
                appointment.Time = new Time();
                appointment.Time.Start = startTime;
                appointment.Time.End = startTime.AddHours(professional.AppointmentLengthInHours);
                // Console.WriteLine("{0} converts to {1}.", model.StartTime.Trim(), startTime.ToString());
            }
            catch (FormatException) 
            {
                // Console.WriteLine("{0} is not in the correct format.", model.StartTime.Trim());
            }

            appointment.IsFufilled = false;
            Repo.Insert<Appointment>(appointment);
            Repo.Save();
            CustomerViewModel customer = new CustomerViewModel();
            customer.Username = appointment.Client.Username;
            return RedirectToAction("Home",customer);

        }
    }
}