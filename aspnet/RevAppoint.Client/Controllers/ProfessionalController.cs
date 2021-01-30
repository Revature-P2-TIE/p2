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

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateProfessional()
    {
      StreamReader streamReader = new StreamReader(Request.Body);
      string body = await streamReader.ReadToEndAsync();

      var professional = JsonConvert.DeserializeObject<Professional>(body);

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
    public async Task<IActionResult> Post()
    {

        StreamReader streamReader = new StreamReader(Request.Body);
        string body = await streamReader.ReadToEndAsync();

        var professional = JsonConvert.DeserializeObject<Professional>(body);
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
    [HttpGet("[action]/{SearchParam}/{ProfessionalSearchValue}")]
    public IActionResult SearchForProfessionals(string SearchParam, string ProfessionalSearchValue)
    {
      var Professionals = _repo.ProfessionalRepo.SearchForProfessionals(SearchParam,ProfessionalSearchValue);
      return Ok(Professionals);
    }
  }
}
