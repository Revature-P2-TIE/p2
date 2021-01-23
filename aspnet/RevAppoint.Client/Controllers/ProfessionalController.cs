using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class ProfessionalController : Controller
    {
        private UnitOfWork Repo;
        public ProfessionalController(UnitOfWork repo)
        {
            Repo = repo;
        }

        [HttpGet("/Professionals")]
        public IEnumerable<Professional> DisplayAllProfessionals()
        {
            return Repo.GetAll<Professional>(); 
        }
    }
}