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
            }else{
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
            var response = await client.GetAsync(apiUrl+apiCustomerController+"/getone/"+id);

            /*
            Getting an object back from the api,
            The api is going to search its database for a user with the credentials that we sent
            and send us back a user based on its search
            */
            // NOTE: this is probably not necessary due to the fact that we just need a username in the next view(passed in as an id), 
            // but I'm leaving it here as a test of our API call -Elmer
            CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(await response.Content.ReadAsStringAsync());
           return View("SearchForProfessional", customer);
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
            model.ListOfProfessionals = 
            Repo.ProfessionalRepo.SearchForProfessionals(model.SearchParam, model.ProfessionalSearchValue);

            return View("DisplayProfessionals", model);
        }
/*
        [HttpGet("/SearchForProfessionals/{id}")]
        public IActionResult SearchForProfessionals(string id)
        {
           CustomerViewModel customer = new CustomerViewModel();
           customer.Customer = Repo.CustomerRepo.GetCustomer(id);
           customer.Username = customer.Customer.Username;
           return View("SearchForProfessional", customer);
        }

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

            AppointmentModel appointment = new AppointmentModel();
            appointment.Client = Repo.CustomerRepo.GetCustomer(id); 
            var professional = appointment.Professional = Repo.ProfessionalRepo.GetProfessional(profid);

            try 
            {
                DateTime startTime = DateTime.ParseExact(model.StartTime.Trim(), format, provider);
                appointment.Time = new TimeModel();
                appointment.Time.Start = startTime;
                appointment.Time.End = startTime.AddHours(professional.AppointmentLengthInHours);
                // Console.WriteLine("{0} converts to {1}.", model.StartTime.Trim(), startTime.ToString());
            }
            catch (FormatException) 
            {
                // Console.WriteLine("{0} is not in the correct format.", model.StartTime.Trim());
            }

            appointment.IsFufilled = false;
            Repo.Insert<AppointmentModel>(appointment);
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
            var Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
            ProfessionalViewModel professional = new ProfessionalViewModel();
            return View("ProfessionalViewPage", model);
        }

        [HttpGet("/ProfessionalView/CreateAppointment")]
        public IActionResult CreateAppointment(CustomerViewModel model)
        {
            return View("CreateAppointment", model);
        }

        [HttpGet("/ProfessionalView/AppointmentCompletion")]
        public IActionResult AppointmentCompletion(CustomerViewModel model)
        {
            return View("AppointmentCompletion", model);
        }

        [HttpGet("/AccountCreationCustomer")]
        public IActionResult AccountCreationCustomer()
        {

            AccountCreationViewModel accountModel = new AccountCreationViewModel();
            return View("AccountCreation", accountModel);
        }

        [HttpPost("/CreateAccount")]
        public IActionResult CreateAccount(AccountCreationViewModel model)
        {
            CustomerModel customer = new CustomerModel(){Username = model.username, Password = model.password,FirstName = model.firstname,LastName = model.lastname,Gender = model.gender,PhoneNumber = model.phonenumber,EmailAddress = model.emailaddress};
            
            Repo.CustomerRepo.AddCustomer(customer);
            return RedirectToAction("GetUser");
        }
    */
    }
}