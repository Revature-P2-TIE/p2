using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Okta.AspNetCore;
using RevAppoint.Client.Models;

namespace RevAppoint.Client.Controllers
{   
    [Route("")]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private string apiUrl = "https://tiemetothemoon.azurewebsites.net/";
        private string loginController = "Login";
        private string apiCustomerController = "Customer";
        private string apiProfessionalController = "Professional";
        private string apiAppointmentController = "Appointment";

        [Authorize]
        [HttpGet("/Login")]
        public IActionResult GetUser()
        {
            LoginViewModel model = new LoginViewModel();
            model.Error = "";
            return View("FormLogin", model);
        }
        
        [Authorize]
        [HttpGet("/Signin")]
        public async Task<IActionResult> Signin()
        {

        //Code to get username goes here

        string username = "";

        foreach(var claim in ((ClaimsIdentity)User.Identity).Claims)
        {
            if(claim.Type == "preferred_username")
            {
                username = claim.Value;
            }
        }
        
        UserModel model = new UserModel();
        model.Username = username;

        var json = JsonConvert.SerializeObject(model);
        StringContent content = new StringContent(json.ToString());

        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        //creating httpclient that uses the handler
        HttpClient client = new HttpClient(clientHandler);
 
        //Passing the serialized object to the API
        var response = await client.GetAsync(apiUrl+apiProfessionalController+"/GetOneUserByUsername/" + username);
        /*
        Getting an object back from the api,
        The api is going to search its database for a user with the credentials that we sent
        and send us back a user based on its search
        */
        UserModel user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
        model.FirstName = user.FirstName;

            if(user.Type =="Customer")
            {
                return View("UserHome", model);
            }
 
           return View("~/Views/Shared/ProfessionalHome.cshtml", model);

        }

        [HttpPost("/UserHome")]
        public async Task<IActionResult> SelectUser(UserModel customer)
        {
            if(customer.FirstName == null)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);
                var response = await client.GetAsync(apiUrl+apiCustomerController+"/GetOneByUsername/"+customer.Username);
                customer = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            }
            return View("UserHome", customer);
        }

        [HttpGet("/SearchForProfessionals/{id}")]
        public async Task<IActionResult> SearchForProfessionals(string id)
        {

            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.GetAsync(apiUrl+apiCustomerController+"/GetOneByUsername/"+id);

            CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync());

           return View("SearchForProfessional", customer);
        }

        [HttpGet("/NEWHOME")]
        public IActionResult SearchForProfessionals()
        {
           return View("NEWHOME");
        }
      
        [HttpGet("/History/{id}")]
        public async Task<IActionResult> AppointmentHistory(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByUsernameFufilled/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.CustomerUsername = id;
            return View("UserHistory",appointment);
        }

        [HttpGet("/CurrentAppointments/{id}")]
        public async Task<IActionResult> CurrentAppointments(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByUsernameAccepted/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.CustomerUsername = id;
            return View("CurrentAppointment", appointment);
        }

        [HttpGet("/PendingAppointments/{id}")]
        public async Task<IActionResult> PendingAppointments(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByUsernamePending/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.CustomerUsername = id;
            return View("PendingAppointments", appointment);
        }
        
        [HttpGet("/Home/{username}")]
        public async Task<IActionResult> Home(string username)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync(apiUrl+apiCustomerController+"/GetOneByUsername/"+username);
            var customer = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());

            var CustomerViewModel = new UserModel();
            CustomerViewModel.Username = customer.Username;
            CustomerViewModel.FirstName = customer.FirstName;
            return View("UserHome", CustomerViewModel);    
        }

        [HttpPost("/Display")]
        public async Task<IActionResult> DisplayProfessionals(CustomerViewModel model)
        {
            //Querying a list of professionals based on users search values
            //then adding them to a list property on the model for use in the view
            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.GetAsync(apiUrl+apiProfessionalController+"/SearchForProfessionals/"+model.SearchParam+"/"+model.ProfessionalSearchValue);
            model.ListOfProfessionals = JsonConvert.DeserializeObject<IEnumerable<ProfessionalModel>>(await response.Content.ReadAsStringAsync());
            return View("DisplayProfessionals", model);
        }


        [HttpPost("/SetAppointment")]
        public async Task<IActionResult> SetAppointment(AppointmentViewModel model)
        {
            //Find the professional
            HttpClientHandler professionalclientHandler = new HttpClientHandler();
            professionalclientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient professionalclient = new HttpClient(professionalclientHandler);
            var professionalresponse = await professionalclient.GetAsync(apiUrl+apiProfessionalController+"/GetOneByUsername/"+model.ProfessionalUsername);
            ProfessionalModel professional = JsonConvert.DeserializeObject<ProfessionalModel>(await professionalresponse.Content.ReadAsStringAsync());
            //Parse Datetimepicker
            AppointmentModel appointment = new AppointmentModel(); 

            string format = "MM/dd/yyyy h:mm tt";
            CultureInfo provider = CultureInfo.InvariantCulture;
            try 
            {
                if(model.StartTime == null)
                {
                    ViewBag.Error = ("Appointment Time Must not be Empty");
                    return View("CreateAppointment", model);
                }
                DateTime startTime = DateTime.ParseExact(model.StartTime.Trim(), format, provider);
                if(startTime < DateTime.Now)
                {
                   ViewBag.Error=("Appointment Time Cannot be in the past");
                    return View("CreateAppointment", model);
                }
                appointment.Time = new TimeModel();
                appointment.Time.Start = startTime;
                appointment.Time.End = startTime.AddHours(professional.AppointmentLengthInHours);
                
            }
            catch (FormatException) 
            {
            }
            
            appointment.IsFufilled = false;
            appointment.Professional= professional;
            appointment.EntityID= DateTime.Now.Ticks;


            //Serializing the model and converting it into a string
            var json = JsonConvert.SerializeObject(appointment.Time);
            StringContent content = new StringContent(json.ToString());
            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.PostAsync(apiUrl+"Appointment"+"/Post/"+model.CustomerUsername+"/"+model.ProfessionalUsername, content); //this is where it's breaking

            CustomerViewModel customerView = new CustomerViewModel();
            customerView.Username = model.CustomerUsername;

            AppointmentViewModel appointmentModel= new AppointmentViewModel();
            appointmentModel.ProfessionalUsername = model.ProfessionalUsername;
            appointmentModel.CustomerUsername = model.CustomerUsername;

            //Return to success page
            return View("AppointmentCompletion",appointmentModel);
        }
        
        [HttpGet("/ProfessionalView")]
        public async Task<IActionResult> ViewProfessional(CustomerViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiProfessionalController+"/GetOneByUsername/"+model.SearchedProfessionalsUsername);
            var professional = JsonConvert.DeserializeObject<ProfessionalModel>(await response.Content.ReadAsStringAsync());
            model.Professional = professional;
            return View("ProfessionalViewPage", model);
        }

        [HttpGet("/ProfessionalView/CreateAppointment")]
        public IActionResult CreateAppointment(CustomerViewModel model)
        {
            AppointmentViewModel appointmentModel= new AppointmentViewModel();
            appointmentModel.ProfessionalUsername = model.SearchedProfessionalsUsername;
            appointmentModel.CustomerUsername = model.Username;
            appointmentModel.AppointmentLengthInHours = model.AppointmentLengthInHours;
            appointmentModel.HourlyRate = model.HourlyRate;
            return View("CreateAppointment", appointmentModel);
        }

         [HttpGet("/AccountCreationCustomer")]
         public IActionResult AccountCreationCustomer()
         {

             AccountCreationViewModel accountModel = new AccountCreationViewModel();
             return View("AccountCreation", accountModel);
         }

         [HttpGet("/AccountCreationProfessional")]
         public IActionResult AccountCreationProfessional()
         {

             ProfessionalModel accountModel = new ProfessionalModel();
             return View("AccountCreationProfessional", accountModel);
         }

         [HttpPost("/CreateAccount")]
        public async Task<IActionResult> CreateAccount(AccountCreationViewModel model)
        {
            CustomerModel customer = new CustomerModel(){Username = model.username, Password = model.password,FirstName = model.firstname,LastName = model.lastname,Gender = model.gender,PhoneNumber = model.phonenumber,EmailAddress = model.emailaddress};

            //Serializing the model and converting it into a string
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json.ToString());

            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
 
            //Passing the serialized object to the API
            var response = await client.PostAsync(apiUrl+loginController+"/CreateAccountClient", content);

            LoginViewModel modelForm = new LoginViewModel();

            if(response.IsSuccessStatusCode)
            {
                return View("FormLogin", modelForm );
            }

            modelForm.Error = "Could Not Create Account!";
            return View("FormLogin", modelForm);
        }
    
        [HttpPost("/CreateAccountProfessional")]
        public async Task<IActionResult> CreateAccountProfessional(ProfessionalModel model)
        {

            //Serializing the model and converting it into a string
            model.MemberSince = DateTime.Now;
            model.Rating = 5;
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json.ToString());

            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
 
            //Passing the serialized object to the API
            var response = await client.PostAsync(apiUrl+loginController+"/CreateAccountProfessional", content);
            /*
            Getting an object back from the api,
            The api is going to search its database for a user with the credentials that we sent
            and send us back a user based on its search
            */
            //UserModel user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());

            LoginViewModel modelForm = new LoginViewModel();

            if(response.IsSuccessStatusCode)
            {
                return View("FormLogin", modelForm );
            }

            modelForm.Error = "Could Not Create Account!";
            return View("FormLogin", modelForm);
        }
    
    }
}