using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RevAppoint.Client.Models;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        private string apiUrl = "http://localhost:7000/";
        private string apiProfessionalController = "Professional";
        private string apiAppointmentController = "Appointment";

        [HttpGet("/Professional/ProfessionalHome")]
        public IActionResult ProfessionalHome(ProfessionalViewModel model)
        {
            UserModel userModel = new UserModel();
            userModel.Username = model.Username;
            return View("ProfessionalHome", userModel);
        }

        /*
        [HttpGet("/Professional/SetAvailability/{id}")]
        public IActionResult SetAvailability(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;
            return View("SetAvailability", model);
        }
        */

         [HttpGet("/Professional/SetAvailability/{id}")]
        public async Task<IActionResult> SetAvailability(string id)
        {
         ProfessionalViewModel model = new ProfessionalViewModel();
         model.Username = id;
         return View("SetAvailability", model);
        
        }

        [HttpGet("/Professional/AppointmentHistory/{id}")]
        public async Task<IActionResult> AppointmentHistory(string id)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByProUsername/"+id);
            var appointments = JsonConvert.DeserializeObject<List<AppointmentModel>>(await response.Content.ReadAsStringAsync());
            AppointmentViewModel appointment = new AppointmentViewModel();
            appointment.Appointments = appointments;
            appointment.ProfessionalUsername = id;
            return View("AppointmentHistory", appointment);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CompleteAppointment(ProfessionalViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/AppointmentComplete/"+model.AppointmentID);
            
            return View("CurrentAppointments", model);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AcceptAppointment(ProfessionalViewModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/AppointmentAccept/"+model.AppointmentID);
            
            return View("CurrentAppointments", model);
        }
    }
}


        // [HttpGet("/Professional/AppointmentHistory/{id}")]
        // public IActionResult AppointmentHistory(string id)
        // {
        //     ProfessionalViewModel model = new ProfessionalViewModel();
        //     model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
        //     model.Username = model.Professional.Username;
           
        //     return View("AppointmentHistory", model);
        // }

        // [HttpGet("/Professional/CurrentAppointments/{id}")]
        // public IActionResult CurrentAppointments(string id)
        // {
        //     ProfessionalViewModel model = new ProfessionalViewModel();
        //     model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
        //     model.Username = model.Professional.Username;

        //     var Customer = Repo.CustomerRepo.GetCustomer(model.Username);

        //     model.CurrentAppointmets = Repo.CustomerRepo.GetAppointments(model.Username).ToList();
    
        //     return View("CurrentAppointments", model);
        // }

        // [HttpGet("/Professional/ClientView/{id}")]
        // public IActionResult ClientView(string id)
        // {
        //     ProfessionalViewModel model = new ProfessionalViewModel();
        //     model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
        //     model.Username = model.Professional.Username;
        //     return View("ClientView", model);
        // }



        // [HttpGet("~/Professional/ProfessionalAccountView/{id}")]
        // public IActionResult ProfessionalAccountView(string id)
        // {
        //     ProfessionalViewModel model = new ProfessionalViewModel();
        //     model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
        //     model.Username = model.Professional.Username;

        //     return View("ProfessionalAccountView", model);
        // }

        // [HttpPost("~/Professional/ProfessionalAccountView/{id}")]
        // public IActionResult EditAccountInfo(string id, ProfessionalViewModel model)
        // {            
        //     ProfessionalViewModel newModel = new ProfessionalViewModel();
        //     newModel.Professional = Repo.ProfessionalRepo.GetProfessional(id);
        //     newModel.Professional.Title = model.Professional.Title;
        //     newModel.Professional.Location = model.Professional.Location;
        //     newModel.Professional.AppointmentLengthInHours = model.Professional.AppointmentLengthInHours;
        //     newModel.Professional.HourlyRate = model.Professional.HourlyRate;
        //     newModel.Professional.Language = model.Professional.Language;
        //     newModel.Professional.Bio = model.Professional.Bio;
        //     newModel.Username = id;
        //     Repo.Update(newModel.Professional);
        //     Repo.Save();
        //     return View("ProfessionalAccountView", newModel);
        // }

