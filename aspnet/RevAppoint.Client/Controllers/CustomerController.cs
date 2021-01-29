  using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpPost("[action]")]
        public IActionResult Post([FromBody]Customer customer)
        {
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

    }
}