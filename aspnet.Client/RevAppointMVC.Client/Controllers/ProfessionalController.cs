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
            var response = await client.GetAsync(apiUrl+apiAppointmentController+"/GetByProUsername/"+id);
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

            HttpClientHandler clientHandler = new HttpClientHandler();
            var json = JsonConvert.SerializeObject(newProf);
            StringContent content = new StringContent(json.ToString());
            Console.WriteLine(json);
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var response = await client.PutAsync(apiUrl+apiProfessionalController+"/UpdateProfessional",content);



            return View("ProfessionalAccountView", newModel);
        }
    }
}
        /*

        [HttpGet("/Professional/AppointmentHistory/{id}")]
        public IActionResult AppointmentHistory(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;
           
            return View("AppointmentHistory", model);
        }

        [HttpGet("/Professional/CurrentAppointments/{id}")]
        public IActionResult CurrentAppointments(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;

            var Customer = Repo.CustomerRepo.GetCustomer(model.Username);

            model.CurrentAppointmets = Repo.CustomerRepo.GetAppointments(model.Username).ToList();
    
            return View("CurrentAppointments", model);
        }

        [HttpGet("/Professional/ClientView/{id}")]
        public IActionResult ClientView(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;
            return View("ClientView", model);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult CompleteAppointment(ProfessionalViewModel model)
        {

            Appointment appointment = Repo.GetById<Appointment>(long.Parse(model.AppointmentID));
            appointment.IsFufilled = true;
            Repo.Save();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
            // model.Username = model.Professional.Username;

            model.CurrentAppointmets = Repo.ProfessionalRepo.GetAppointments(model.Professional.EntityID).ToList();
            return View("CurrentAppointments", model);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AcceptAppointment(ProfessionalViewModel model)
        {
            Appointment appointment = Repo.GetById<Appointment>(long.Parse(model.AppointmentID));;
            appointment.IsAccepted = !appointment.IsAccepted;
            Repo.Save();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(model.Username);
            model.CurrentAppointmets = Repo.ProfessionalRepo.GetAppointments(model.Professional.EntityID).ToList();
            return View("CurrentAppointments", model);
        }

        [HttpGet("~/Professional/ProfessionalAccountView/{id}")]
        public IActionResult ProfessionalAccountView(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;

            return View("ProfessionalAccountView", model);
        }
*/