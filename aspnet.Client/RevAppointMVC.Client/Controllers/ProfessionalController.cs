using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;

namespace RevAppoint.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        private string apiUrl = "http://localhost:5000/";
        private HttpClient _http = new HttpClient();

        [HttpGet("/Professional/ProfessionalHome")]
        public IActionResult ProfessionalHome(ProfessionalViewModel model)
        {

            return View("ProfessionalHome", model);
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
         
            var response = await _http.GetAsync(apiUrl);

                return View("SetAvailability", response);

            
           
    /*
        if(response.IsSuccessStatusCode){

            var response.Con
            return View("SetAvailability", content);
        
        }
    */
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

        */