using System.IO;
using System.Linq;
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
    [Produces("application/json")]
    public class LoginController:ControllerBase
    {
        private UnitOfWork _repo;
        private HttpClient _http = new HttpClient();

        public LoginController(UnitOfWork repo)
        {
            _repo = repo;
        }

         [HttpGet("[action]")]
        public IActionResult Get(/*User user*/)
        {
                  System.Console.WriteLine("TEST");
    
                return NotFound();  
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Post()
        {
        
        StreamReader streamReader = new StreamReader(Request.Body);

        //var body = Request.HttpContent.ToString();
        //  var obj = JsonConvert.DeserializeObject<User>(bod);

           string body = await streamReader.ReadToEndAsync();
           var obj = JsonConvert.DeserializeObject<User>(body);
           System.Console.WriteLine(obj.Username);
            // System.Console.WriteLine(obj);
              
           // if (ModelState.IsValid)
           // {
                var User = _repo.UserRepo.GetUser(obj.Username,obj.Password);
              if (User != null)
               {
                    return Ok(User);
                }
                return NotFound();
           // }
           // else
          //  {
          //      return NotFound();
           // }
        }
    }
}