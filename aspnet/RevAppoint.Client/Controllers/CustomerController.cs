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
        public CustomerController(UnitOfWork repo)
        {
            Repo = repo;
        }

        [HttpGet("/Customer")]
        public IActionResult GetUser()
        {
            return View("Login", new CustomerViewModel(Repo));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectUser(CustomerViewModel customer)
        {
            if(ModelState.IsValid)
            {
                customer.Customer = Repo.CustomerRepo.GetCustomer(customer.Username);
                // Client.OrderHistory = Repo.OrderRepo.GetOrderByUser(Client.User);
                return View("UserHome", customer);
            }
            else
            {
                customer.Customers = Repo.GetAll<Customer>();
                return View("Login", customer);
            }
        }
    }
}