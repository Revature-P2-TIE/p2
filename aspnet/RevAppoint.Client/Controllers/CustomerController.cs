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
            else
            {
                customer.Customers = Repo.GetAll<Customer>();
                return View("Login", customer);
            }
        }

        [HttpGet("/Professionals/{id}")]
        public IActionResult DisplayProfessionals(string id)
        {
            if(id != null)
            {
                var professional = new ProfessionalViewModel(Repo);
                professional.Username = RouteData.Values["id"].ToString();
                return View("DisplayProfessionals", professional);
            }
            else
            {
                return RedirectToAction("GetUser");
            }
        }
        [Route("AppointmentHistory")]
        [HttpGet("/AppointmentHistory")]
        public IActionResult AppointmentHistory(AppointmentViewModel model, string id)
        {
            if(model != null)
            {
                AppointmentViewModel appointment = new AppointmentViewModel();
                appointment.Appointments = Repo.CustomerRepo.GetAppointments(id).ToList();
                return View("UserHistory",appointment);

            }
            else
            {
                return RedirectToAction("GetUser");
            }

        }
        [HttpPost("/Customer/SelectTime")]
        public IActionResult SelectTime(string id)
        {
            AppointmentViewModel appointment = new AppointmentViewModel();
            return View("SelectTime");

        }
        [HttpPost("/Customer/PostAppointment")]
        public IActionResult PostAppointment(AppointmentViewModel model)
        {
            System.Console.WriteLine(model.StartTime.Trim());
            string format = "MM/dd/yyyy h:mm tt";
            CultureInfo provider = CultureInfo.InvariantCulture;
            Appointment appointment = new Appointment();
            try {
                DateTime startTime = DateTime.ParseExact(model.StartTime.Trim(), format, provider);
                appointment.Time = new Time();
                appointment.Time.Start = startTime;
                appointment.Time.End = startTime.AddHours(2);
                // Console.WriteLine("{0} converts to {1}.", model.StartTime.Trim(), startTime.ToString());

            }
            catch (FormatException) {
                // Console.WriteLine("{0} is not in the correct format.", model.StartTime.Trim());
            }

            appointment.Client = Repo.GetAll<Customer>().Last();
            appointment.Professional = Repo.GetAll<Professional>().Last();
            appointment.IsFufilled = false;
            Repo.Insert<Appointment>(appointment);
            Repo.Save();
            return View("SelectTime");

        }

    }
}