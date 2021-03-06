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
      var oldProfessional = _repo.ProfessionalRepo.GetProfessional(professional.Username);
      oldProfessional.Title = professional.Title;
      oldProfessional.Location = professional.Location;
      oldProfessional.AppointmentLengthInHours = professional.AppointmentLengthInHours;
      oldProfessional.HourlyRate = professional.HourlyRate;
      oldProfessional.Language = professional.Language;
      oldProfessional.Bio = professional.Bio;


      _repo.Update(oldProfessional);
      _repo.Save();
      streamReader.Close();
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
        streamReader.Close();
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
    [HttpGet("[action]/{username}")]
    public IActionResult GetOneByUsername(string username)
    {
        var Professional = _repo.ProfessionalRepo.GetProfessional(username);
        return Ok(Professional);
    }
    [HttpGet("[action]/{username}")]
    public IActionResult GetOneUserByUsername(string username)
    {
        var User = _repo.UserRepo.GetUser(username);

        if (User ==null)
        {
        Console.WriteLine("not found");
          return NotFound();
        }
        return Ok(User);
    }
  }
}
