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
        public async Task<IActionResult> CreateAccountClient()
        {
        
        //Reading the Body/Context of the request
        StreamReader streamReader = new StreamReader(Request.Body);
        string body = await streamReader.ReadToEndAsync();

        //Deserializing the object that was sent in the context
        var obj = JsonConvert.DeserializeObject<Customer>(body);

        //Testing 
        System.Console.WriteLine(obj.Username);
    
        /*
        Searching the repo for a username/password combo that matches 
        the users input
        */
        //ADD CHECKING HERE FOR VALID USERNAME
        if(_repo.CustomerRepo.AddCustomer(obj))
        {
          return Ok();
        }
        return NotFound();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAccountProfessional()
        {
        
        //Reading the Body/Context of the request
        StreamReader streamReader = new StreamReader(Request.Body);
        string body = await streamReader.ReadToEndAsync();

        //Deserializing the object that was sent in the context
        var obj = JsonConvert.DeserializeObject<Professional>(body);

        //Testing 
        System.Console.WriteLine(obj.Username);
    
        /*
        Searching the repo for a username/password combo that matches 
        the users input
        */
        //ADD CHECKING HERE FOR VALID USERNAME
        if(_repo.ProfessionalRepo.AddProfessional(obj))
        {
          return Ok();
        }
        return NotFound();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post()
        {
        
        //Reading the Body/Context of the request
        StreamReader streamReader = new StreamReader(Request.Body);
        string body = await streamReader.ReadToEndAsync();

        //Deserializing the object that was sent in the context
        var obj = JsonConvert.DeserializeObject<User>(body);

        //Testing 
        System.Console.WriteLine(obj.Username);
    
        /*
        Searching the repo for a username/password combo that matches 
        the users input
        */
        var User = _repo.UserRepo.GetUser(obj.Username,obj.Password);

        //Sending a response back with the user from the repo
        if (User != null)
        {
          return Ok(User);
        }
        return NotFound();
  
        }
    }
}