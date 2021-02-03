using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RevAppoint.Client.Models;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        private string apiUrl = "https://tiemetothemoon.azurewebsites.net/";
        private string apiProfessionalController = "Professional";
        private string apiAppointmentController = "Appointment";

        [HttpGet("/Professional/ProfessionalHome")]
        public async Task<IActionResult> ProfessionalHome(ProfessionalViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiProfessionalController+"/GetOneUserByUsername/"+model.Username);
            var userModel = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            return View("ProfessionalHome", userModel);
        }

         [HttpGet("/Professional/SetAvailability/{id}")]
        public async Task<IActionResult> SetAvailability(string id)
        {
         ProfessionalViewModel model = new ProfessionalViewModel();
         model.Username = id;
         return View("SetAvailability", model);
        
        }

        [HttpGet("/Professional/ViewProfile/{id}")]
        public async Task<IActionResult> ViewProfile(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiProfessionalController+"/GetOneByUsername/"+id);
            var professional = JsonConvert.DeserializeObject<ProfessionalModel>(await response.Content.ReadAsStringAsync());
            ProfessionalViewModel professionalView = new ProfessionalViewModel();
            professionalView.Professional = professional;
            professionalView.Username = id;
            return View("ProfessionalAccountView",professionalView);
        
        }

        [HttpGet("/Professional/AppointmentHistory/{id}")]
        public async Task<IActionResult> AppointmentHistory(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByProUsernameFufilled/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.ProfessionalUsername = id;
            return View("AppointmentHistory", appointment);
        }

        [HttpPost("~/Professional/ProfessionalAccountView/{id}")]
        public async Task<IActionResult> EditAccountInfoAsync(string id, ProfessionalViewModel model)
        {            
            ProfessionalViewModel newModel = new ProfessionalViewModel();
            ProfessionalModel newProf = new ProfessionalModel();
            newProf.Title = model.Professional.Title;
            newProf.Location = model.Professional.Location;
            newProf.AppointmentLengthInHours = model.Professional.AppointmentLengthInHours;
            newProf.HourlyRate = model.Professional.HourlyRate;
            newProf.Language = model.Professional.Language;
            newProf.Bio = model.Professional.Bio;
            newProf.Username = id;

            newModel.Professional = newProf;
            newModel.Professional.Rating = model.Professional.Rating;
            newModel.Username = id;

            HttpClientHandler clientHandler = new HttpClientHandler();
            var json = JsonConvert.SerializeObject(newProf);
            StringContent content = new StringContent(json.ToString());
            Console.WriteLine(json);
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.PutAsync(apiUrl+apiProfessionalController+"/UpdateProfessional",content);

            return View("ProfessionalAccountView", newModel);
        }

        [HttpGet("/Professional/PendingAppointments/{id}")]
        public async Task<IActionResult> PendingAppointments(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByProUsernamePending/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.ProfessionalUsername = id;
            return View("PendingAppointments", appointment);
        }

        [HttpGet("/Professional/CurrentAppointments/{id}")]
        public async Task<IActionResult> CurrentAppointments(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByProUsernameAccepted/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.ProfessionalUsername = id;
            return View("CurrentAppointments", appointment);

        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CompleteAppointment(AppointmentViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/AppointmentComplete/"+model.AppointmentID);
            HttpClientHandler clientHandler2 = new HttpClientHandler();
            clientHandler2.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client2 = new HttpClient(clientHandler2);
            var response2 = await client2.GetAsync(apiUrl+apiProfessionalController+"/GetOneUserByUsername/"+model.ProfessionalUsername);
            UserModel user = JsonConvert.DeserializeObject<UserModel>(await response2.Content.ReadAsStringAsync());

            return View("ProfessionalHome", user);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AcceptAppointment(AppointmentViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/AppointmentAccept/"+model.AppointmentID);
            HttpClientHandler clientHandler2 = new HttpClientHandler();
            clientHandler2.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client2 = new HttpClient(clientHandler2);
            var response2 = await client2.GetAsync(apiUrl+apiProfessionalController+"/GetOneUserByUsername/"+model.ProfessionalUsername);
            UserModel user = JsonConvert.DeserializeObject<UserModel>(await response2.Content.ReadAsStringAsync());
            return View("ProfessionalHome", user);
        }
    }
}

