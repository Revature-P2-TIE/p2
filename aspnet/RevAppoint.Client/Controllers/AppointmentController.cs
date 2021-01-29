using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController:ControllerBase
    {
        private UnitOfWork _repo;
        private HttpClient _http = new HttpClient();

        public AppointmentController(UnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var Appointment = _repo.GetAll<Appointment>();
            return Ok(Appointment);
        }
        
        [HttpGet("[action]/{id}")]
        public IActionResult GetOne(long id)
        {
            var Appointment = _repo.GetById<Appointment>(id);
            return Ok(Appointment);
        }

        [HttpGet("[action]/{username}")]
        public IActionResult GetByUsername(string username)
        {
            var Appointments = _repo.CustomerRepo.GetAppointments(username);
            return Ok(Appointments);
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody]Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repo.Insert<Appointment>(appointment);
                _repo.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}