using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class AppointmentController : Controller
    {
        private UnitOfWork Repo;
        public AppointmentController(UnitOfWork repo)
        {
            Repo = repo;
        }
        [HttpPost]
        public IActionResult DeleteAppointment(CustomerViewModel model)
        {
            // Repo.Delete<Appointment>(model.Appointment.EntityID);
            return View();
        }


    }
}