using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RevAppoint.Client.Models;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private string apiUrl = "http://localhost:7000/";
        private string loginController = "Login";
        private string apiCustomerController = "Customer";
        private string apiProfessionalController = "Professional";
        private string apiAppointmentController = "Appointment";

      //  private HttpClient _http = new HttpClient();

        [HttpGet("/Login")]
        public IActionResult GetUser()
        {
            return View("FormLogin");
        }

        
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
            if(user.Type == "Customer"){
                return View("UserHome", user);
            }
            else{
                return View("~/Views/Shared/ProfessionalHome.cshtml", user);
            }
        }
          
        //This will happen if the username/password combo provided is not in the system
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View("FormLogin");

        }

        [HttpPost("/UserHome")]
        public IActionResult SelectUser(CustomerViewModel customer)
        {
                return View("UserHome", customer);
        }

        [HttpGet("/SearchForProfessionals/{id}")]
        public async Task<IActionResult> SearchForProfessionals(string id)
        {
            // var json = JsonConvert.SerializeObject(id);
            // StringContent content = new StringContent(json.ToString());

            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.GetAsync(apiUrl+apiCustomerController+"/GetOneByUsername/"+id);

            /*
            Getting an object back from the api,
            The api is going to search its database for a user with the credentials that we sent
            and send us back a user based on its search
            */
            // NOTE: this is probably not necessary due to the fact that we just need a username in the next view(passed in as an id), 
            // but I'm leaving it here as a test of our API call -Elmer
            CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync());
            // Console.WriteLine(customer.Username);
            // customer.Username = id;
           return View("SearchForProfessional", customer);
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

        /*
        [HttpPost("/Home")]
        public async Task<IActionResult> FormLogin(LoginViewModel model)
        {
            var user = await _http.GetAsync(apiUrl);
             Repo.UserRepo.GetUser(model.Username, model.Password);
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
                    customer.Username = model.Username;
                    return RedirectToAction("Home",new {
                    username = customer.Username});
                }
                else{
                    ProfessionalViewModel professional = new ProfessionalViewModel();
                    professional.Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
                    return View("~/Views/Shared/ProfessionalHome.cshtml", professional);
                }
            }
        }

 /*       [HttpPost("/Home")]
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
                    customer.Username = model.Username;
                    return RedirectToAction("Home",new {
                        username = customer.Username});
                }
               else{
                   ProfessionalViewModel professional = new ProfessionalViewModel();
                   professional.Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
                   return View("~/Views/Shared/ProfessionalHome.cshtml", professional);
                }
            }
        }*/
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
        public async Task<IActionResult> DisplayProfessionals(CustomerViewModel model)
        {
            //Querying a list of professionals based on users search values
            //then adding them to a list property on the model for use in the view
            // model.ListOfProfessionals = 
            // Repo.ProfessionalRepo.SearchForProfessionals(model.SearchParam, model.ProfessionalSearchValue);
            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.GetAsync(apiUrl+apiProfessionalController+"/SearchForProfessionals/"+model.SearchParam+"/"+model.ProfessionalSearchValue);
            model.ListOfProfessionals = JsonConvert.DeserializeObject<IEnumerable<ProfessionalModel>>(await response.Content.ReadAsStringAsync());
            // model.Username = model.Username;
            // IEnumerable<ProfessionalViewModel> professionals = JsonConvert.DeserializeObject<IEnumerable<ProfessionalViewModel>>(await response.Content.ReadAsStringAsync());
            return View("DisplayProfessionals", model);
        }


        // [HttpGet("/SearchForProfessionals/{id}")]
        // public IActionResult SearchForProfessionals(string id)
        // {
        //    CustomerViewModel customer = new CustomerViewModel();
        //    customer.Customer = Repo.CustomerRepo.GetCustomer(id);
        //    customer.Username = customer.Customer.Username;
        //    return View("SearchForProfessional", customer);
        // }

        // [HttpGet("/Home/{username}")]
        // public IActionResult Home(string username)
        // {
        //     var CustomerViewModel = new CustomerViewModel();
        //     CustomerViewModel.Username = username;
        //     CustomerViewModel.Customer = Repo.CustomerRepo.GetCustomer(username);
        //     return View("UserHome", CustomerViewModel);    
        // }

        // [HttpGet("/History/{id}")]
        // public IActionResult AppointmentHistory(string id)


        // [HttpGet("/SearchForProfessionals/{id}")]
        // public IActionResult SearchForProfessionals(string id)
        // {
        //    CustomerViewModel customer = new CustomerViewModel();
        //    customer.Customer = Repo.CustomerRepo.GetCustomer(id);
        //    customer.Username = customer.Customer.Username;
        //    return View("SearchForProfessional", customer);
        // }

      
        // [HttpGet("/History/{id}")]
        // public IActionResult AppointmentHistory(string id)
        
        // {
        //     AppointmentViewModel appointment = new AppointmentViewModel();
        //     var Customer = Repo.CustomerRepo.GetCustomer(id);
        //     appointment.Appointments = Repo.CustomerRepo.GetAppointments(Customer.EntityID).ToList();
        //     appointment.CustomerUsername = Customer.Username;
        //     return View("UserHistory",appointment);
        // }
        
        // [HttpPost("/SelectTime")]
        // public IActionResult SelectTime(string id,string profid)
        // {
        //     AppointmentViewModel appointment = new AppointmentViewModel();
        //     appointment.Professional = Repo.ProfessionalRepo.GetProfessional(profid);
        //     appointment.Customer = Repo.CustomerRepo.GetCustomer(id);

        //     return View("SelectTime", appointment);
        // }

        [HttpPost("/SetAppointment")]
        public async Task<IActionResult> SetAppointment(AppointmentViewModel model)
        {
        
            
            //Getting an object back from the api,
            //The api is going to search its database for a user with the credentials that we sent
            //and send us back a user based on its search
            
            // UserModel user = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
       
            //If the username/password combo is in the API's database, we will have a binded model
            
            
            //Find the customer
            Console.WriteLine("Customer User Name"+model.CustomerUsername);
            // HttpClientHandler customerclientHandler = new HttpClientHandler();
            // customerclientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // HttpClient customerclient = new HttpClient(customerclientHandler);
            // var customerresponse = await customerclient.GetAsync(apiUrl+apiCustomerController+"/GetOneByUsername/"+model.CustomerUsername);
            // CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(await customerresponse.Content.ReadAsStringAsync());

            //Find the professional
            HttpClientHandler professionalclientHandler = new HttpClientHandler();
            professionalclientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient professionalclient = new HttpClient(professionalclientHandler);
            var professionalresponse = await professionalclient.GetAsync(apiUrl+apiProfessionalController+"/GetOneByUsername/"+model.ProfessionalUsername);
            ProfessionalModel professional = JsonConvert.DeserializeObject<ProfessionalModel>(await professionalresponse.Content.ReadAsStringAsync());
            // Console.WriteLine(professional.Username);
            //Parse Datetimepicker
            AppointmentModel appointment = new AppointmentModel(); 

            // appointment.Client = Repo.CustomerRepo.GetCustomer(id); 
            // var professional = appointment.Professional = Repo.ProfessionalRepo.GetProfessional(profid);
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
            // appointment.Client = customer;
            appointment.EntityID= DateTime.Now.Ticks;

            // Repo.Insert<AppointmentModel>(appointment);
            // Repo.Save();

            //Serializing the model and converting it into a string
            var json = JsonConvert.SerializeObject(appointment.Time);
            StringContent content = new StringContent(json.ToString());
            Console.WriteLine(json); 
            //Creating a HTTP handler to bypass SSL cert checks
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            //creating httpclient that uses the handler
            HttpClient client = new HttpClient(clientHandler);
    
            //Passing the serialized object to the API
            var response = await client.PostAsync(apiUrl+"Appointment"+"/Post/"+model.CustomerUsername+"/"+model.ProfessionalUsername, content); //this is where it's breaking

            CustomerViewModel customerView = new CustomerViewModel();
            customerView.Username = model.CustomerUsername;
            // return RedirectToAction("Home",customerView);

            AppointmentViewModel appointmentModel= new AppointmentViewModel();
            appointmentModel.ProfessionalUsername = model.ProfessionalUsername;
            appointmentModel.CustomerUsername = model.CustomerUsername;
            return View("CreateAppointment",appointmentModel);
        }
        
        // [HttpGet("/CurrentAppointments/{id}")]
        // public IActionResult CurrentAppointments(string id)
        // {
        //     CustomerViewModel customer = new CustomerViewModel();
        //     customer.Customer = Repo.CustomerRepo.GetCustomer(id);
        //     customer.Username = customer.Customer.Username;
        //     return View("CurrentAppointment", customer);
        // }

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
            return View("CreateAppointment", appointmentModel);
        }

        // [HttpGet("/ProfessionalView/AppointmentCompletion")]
        // public IActionResult AppointmentCompletion(CustomerViewModel model)
        // {
        //     return View("AppointmentCompletion", model);
        // }

        // [HttpGet("/AccountCreationCustomer")]
        // public IActionResult AccountCreationCustomer()
        // {

        //     AccountCreationViewModel accountModel = new AccountCreationViewModel();
        //     return View("AccountCreation", accountModel);
        // }

        // [HttpPost("/CreateAccount")]
        // public IActionResult CreateAccount(AccountCreationViewModel model)
        // {
        //     CustomerModel customer = new CustomerModel(){Username = model.username, Password = model.password,FirstName = model.firstname,LastName = model.lastname,Gender = model.gender,PhoneNumber = model.phonenumber,EmailAddress = model.emailaddress};
            
        //     Repo.CustomerRepo.AddCustomer(customer);
        //     return RedirectToAction("GetUser");
        // }
    
    }
}