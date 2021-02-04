using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        // [Authorize]
        // [HttpGet("/Signin")]
        // [HttpPost("/Signin")]
        // public IActionResult GetUser1()
        // {
        //     LoginViewModel model = new LoginViewModel();
        //     model.Error = "";
        //     return View("NEWHOME");
        // }
        
        [HttpGet("/Signin")]
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }
            var userClaims = HttpContext.User.Claims;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("/authorization-code/callback")]
        public IActionResult breakme()
        {
            return RedirectToAction("Index", "Home");
        }
        
        // [HttpGet("/Signin")]
        // public IActionResult SignIn()
        // {
        //     if (!HttpContext.User.Identity.IsAuthenticated)
        //     {
        //         return Challenge(OktaDefaults.MvcAuthenticationScheme);
        //     }
        //     return RedirectToAction("GetUser1", "Customer");
        // }

        [HttpPost("/Login")]
        public async Task<IActionResult> FormLogin(LoginViewModel model)
        {
  
        //Serializing the model and converting it into a string
        var json = JsonConvert.SerializeObject(model);
        StringContent content = new StringContent(json.ToString());

        //Creating a HTTP handler to bypass SSL cert checks
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        
        //creating httpclient that uses the handler
        HttpClient client = new HttpClient(clientHandler);
 
        //Passing the serialized object to the API
        var response = await client.PostAsync(apiUrl+loginController+"/Post", content);
        /*
        Getting an object back from the api,
        The api is going to search its database for a user with the credentials that we sent
        and send us back a user based on its search
        */
        UserModel user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
       
        //If the username/password combo is in the API's database, we will have a binded model
        if(user.Username != null)
        {
            if(user.Type.Equals("Customer")){
                return View("UserHome", user);
            }
            else{
                return View("~/Views/Shared/ProfessionalHome.cshtml", user);
            }
        }
          
        //This will happen if the username/password combo provided is not in the system
     
            LoginViewModel modelLogin = new LoginViewModel();
            modelLogin.Error = "Invalid login attempt.";
            return View("FormLogin", modelLogin);
        }

        [HttpPost("/")]
        public IActionResult FindUser(UserModel customer)
        {
                return View("UserHome", customer);
        }

        [HttpPost("/UserHome")]
        public IActionResult SelectUser(UserModel customer)
        {
                return View("UserHome", customer);
        }

        [Route("")]
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
           return View("TestView");
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
        public IActionResult Home(string username)
        {
            var CustomerViewModel = new UserModel();
            CustomerViewModel.Username = username;
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
        
            Console.WriteLine("Customer User Name"+model.CustomerUsername);
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
                DateTime startTime = DateTime.ParseExact(model.StartTime.Trim(), format, provider);
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