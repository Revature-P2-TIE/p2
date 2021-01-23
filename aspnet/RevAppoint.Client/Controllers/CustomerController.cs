using Microsoft.AspNetCore.Mvc;
using RevAppoint.Client.Models;
using RevAppoint.Domain.POCOs;
using RevAppoint.Repo.Repositories;

namespace RevAppoint.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private UnitOfWork Repo;
        public CustomerController(UnitOfWork _repo)
        {
            Repo = _repo;
        }

        [HttpGet("/Client")]
        public IActionResult GetUser()
        {
            return View("Login", new CustomerViewModel(Repo));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectUser(CustomerViewModel _customer)
        {
        if(ModelState.IsValid)
        {
            _customer.Customer = Repo.CustomerRepo.GetCustomer(_customer.Username);
            // Client.OrderHistory = Repo.OrderRepo.GetOrderByUser(Client.User);
            return View("Login",_customer);
        }
        else
        {
            _customer.Customers = Repo.GetAll<Customer>();
            return View("Customer",_customer);
        }
        }
    }
}