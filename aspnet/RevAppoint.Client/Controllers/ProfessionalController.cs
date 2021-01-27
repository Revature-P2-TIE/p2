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


            model.CurrentAppointmets = Repo.ProfessionalRepo.GetAppointments(model.Professional.EntityID).ToList();
    
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
            appointment.IsAccepted = true;
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
    }
}