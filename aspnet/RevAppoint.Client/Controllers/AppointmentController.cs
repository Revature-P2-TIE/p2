using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost("[action]/{CustomerUsername}/{ProfessionalUsername}")]
        public async Task<IActionResult> Post(string CustomerUsername,string ProfessionalUsername)
        {
                    
        //Reading the Body/Context of the request
            StreamReader streamReader = new StreamReader(Request.Body);
            string body = await streamReader.ReadToEndAsync();
            System.Console.WriteLine(body);
            var Time = JsonConvert.DeserializeObject<Time>(body);
            Appointment appointment = new Appointment();
            appointment.Time = Time;
            appointment.Professional = _repo.ProfessionalRepo.GetProfessional(ProfessionalUsername);
            appointment.Client = _repo.CustomerRepo.GetCustomer(CustomerUsername);
            appointment.IsAccepted = false;
            appointment.IsFufilled = false;
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