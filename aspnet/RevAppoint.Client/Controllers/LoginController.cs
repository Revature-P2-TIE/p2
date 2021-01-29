using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController:ControllerBase
    {
        private UnitOfWork _repo;
        private HttpClient _http = new HttpClient();

        public LoginController(UnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                var User = _repo.UserRepo.GetUser(user.Username,user.Password);
                if (User != null)
                {
                    return Ok(User);
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}