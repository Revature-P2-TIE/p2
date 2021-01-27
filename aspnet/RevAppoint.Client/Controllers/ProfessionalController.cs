using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        private UnitOfWork Repo;
        public ProfessionalController(UnitOfWork repo)
        {
            Repo = repo;
        }

        [HttpGet("/Professional/ProfessionalHome")]
        public IActionResult ProfessionalHome(ProfessionalViewModel model)
        {

            return View("ProfessionalHome", model);
        }

        [HttpGet("/Professional/SetAvailability/{id}")]
        public IActionResult SetAvailability(string id)
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;
            return View("SetAvailability", model);
        }

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
<<<<<<< HEAD
        [HttpPut]
        public IActionResult CompleteAppointment(ProfessionalViewModel model)
=======

        [HttpGet("~/Professional/ProfessionalAccountView/{id}")]
        public IActionResult ProfessionalAccountView(string id)
>>>>>>> f3d8eb0b4f5fa2aac1310b03e250cc4475ce2c97
        {
            ProfessionalViewModel model = new ProfessionalViewModel();
            model.Professional = Repo.ProfessionalRepo.GetProfessional(id);
            model.Username = model.Professional.Username;
<<<<<<< HEAD

            return View("ClientView", model);
=======
            return View("ProfessionalAccountView", model);
>>>>>>> f3d8eb0b4f5fa2aac1310b03e250cc4475ce2c97
        }
    }
}