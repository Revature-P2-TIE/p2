using System;
using System.Collections.Generic;
using System.Globalization;
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
            return View("FormLogin");
        }

        [HttpPost("/FormLogin")]
        public IActionResult FormLogin(LoginViewModel model)
        {
            var user = Repo.UserRepo.GetUser(model.Username, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View("FormLogin");
            }
            else
            {
               if(user.Type == "Customer"){
                    CustomerViewModel customer = new CustomerViewModel();
                    customer.Customer = Repo.CustomerRepo.GetCustomer(model.Username);
                    return View("UserHome", customer);
               }else{
                   ProfessionalViewModel professional = new ProfessionalViewModel();
                   professional.Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
                   return View("/Professional/ProfessionalHome/", professional);
               }
            }
        }
/*
        [HttpGet("/Customer")]
        public IActionResult GetUser()
        {
            CustomerViewModel model = new CustomerViewModel(Repo);
            model.Professionals = Repo.GetAll<Professional>();
            //Repo.ProfessionalRepo.GetProfessionals();
            return View("Login", model);
        }

        [HttpPost("/Home")]
        public IActionResult SelectUser(CustomerViewModel customer)
        {
 
            if(ModelState.IsValid)
            {
                customer.Customer = Repo.CustomerRepo.GetCustomer(customer.Username);
                return View("UserHome", customer);
            }
            //TODO ADD LOGIC TO CHECH IF THEY ARE A PROFESSIONAL
            else
            {
                customer.Customers = Repo.GetAll<Customer>();
                customer.Professionals = Repo.ProfessionalRepo.GetProfessionals();
                return View("Login", customer);
            }
        }
*/
        [HttpPost("/Display")]
        public IActionResult DisplayProfessionals(CustomerViewModel model)
        {
            //Querying a list of professionals based on users search values
            //then adding them to a list property on the model for use in the view
            model.ListOfProfessionals = 
            Repo.ProfessionalRepo.SearchForProfessionals(model.SearchParam, model.ProfessionalSearchValue);

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
        /*
        [HttpGet("/AppointmentHistory/{id}")]
        public IActionResult AppointmentHistory(string customerUsername)
        */
        [HttpGet("/Home/{username}")]
        public IActionResult Home(string username)
        {
            var CustomerViewModel = new CustomerViewModel();
            CustomerViewModel.Username = username;
            CustomerViewModel.Customer = Repo.CustomerRepo.GetCustomer(username);
            return View("UserHome", CustomerViewModel);    
        }

        [HttpGet("/History/{id}")]
        public IActionResult AppointmentHistory(string id)

        {
            AppointmentViewModel appointment = new AppointmentViewModel();
            var Customer = Repo.CustomerRepo.GetCustomer(id);
            appointment.Appointments = Repo.CustomerRepo.GetAppointments(Customer.EntityID).ToList();
            appointment.CustomerUsername = Customer.Username;
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
        
        [HttpGet("/CurrentAppointments/{id}")]
        public IActionResult CurrentAppointments(string id)
        {
           CustomerViewModel customer = new CustomerViewModel();
           customer.Customer = Repo.CustomerRepo.GetCustomer(id);
            customer.Username = customer.Customer.Username;
            return View("CurrentAppointment", customer);
        }

        [HttpPost("/ProfessionalView")]
        public IActionResult ViewProfessional(CustomerViewModel model)
        {
            return View("ProfessionalViewPage", model);
        }
        [HttpGet("/ProfessionalView/CreateAppointment")]
        public IActionResult CreateAppointment(CustomerViewModel model)
        {

            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Professional = Repo.ProfessionalRepo.GetProfessional(model.SearchedProfessionalsUsername);
            appointment.Customer = Repo.CustomerRepo.GetCustomer(model.Username);

            return View("CreateAppointment", appointment);
        }

        [HttpGet("/ProfessionalView/AppointmentCompletion")]
        public IActionResult AppointmentCompletion(CustomerViewModel model)
        {
            return View("AppointmentCompletion", model);
        }
    }
}