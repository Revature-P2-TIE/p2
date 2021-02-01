  using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController:ControllerBase
    {
        private UnitOfWork _repo;
        private HttpClient _http = new HttpClient();

        public CustomerController(UnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var Customers = _repo.GetAll<Customer>();
            return Ok(Customers);
        }
        
        [HttpGet("[action]/{id}")]
        public IActionResult GetOne(long id)
        {
            var Customer = _repo.GetById<Customer>(id);
            return Ok(Customer);
        }
        [HttpGet("[action]/{username}")]
        public IActionResult GetOneByUsername(string username)
        {
            var Customer = _repo.CustomerRepo.GetCustomer(username);
            return Ok(Customer);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post()
        {
            StreamReader streamReader = new StreamReader(Request.Body);
            string body = await streamReader.ReadToEndAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(body);
            streamReader.Close();
            if (ModelState.IsValid)
            {
                _repo.Insert<Customer>(customer);
                _repo.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer()
        {
            StreamReader streamReader = new StreamReader(Request.Body);
            string body = await streamReader.ReadToEndAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(body);
            streamReader.Close();
            if (ModelState.IsValid)
            {
                _repo.Update<Customer>(customer);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}