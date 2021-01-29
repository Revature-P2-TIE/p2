using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace  aspnet.RevAppoint.Client
{
  [ApiController]
  [Route("[controller]")]
  public class ProfessionalController : ControllerBase
  {
    private UnitOfWork _repo;
    public ProfessionalController(UnitOfWork repo)
    {
      _repo = repo;
    }

    [HttpGet("[action]")]
    public IActionResult GetAllProfessionals()
    {
      var professionals = _repo.GetAll<Professional>();

      return Ok(professionals);
    }

    [HttpPut("[action]/{id}")]
    public IActionResult PutProfessional(string id,[FromBody]Professional professional)
    {
      // if (id != professional.Username)
      // {
      //     return BadRequest();
      // }
      _repo.Update(professional);
      return Ok();

    }

    [HttpGet("[action]/{id}")]
    public IActionResult GetOne(long id)
    {
        var Professional = _repo.GetById<Professional>(id);
        return Ok(Professional);
    }

    [HttpPost("[action]")]
    public IActionResult Post([FromBody]Professional professional)
    {
        if (ModelState.IsValid)
        {
            _repo.Insert<Professional>(professional);
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
