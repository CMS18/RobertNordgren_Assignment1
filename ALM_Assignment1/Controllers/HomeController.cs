using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALM_Assignment1.Models;
using ALM_Assignment1.ViewModels;

namespace ALM_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankRepository _repo;

        public HomeController(IBankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var customers = _repo.GetCustomers();
            var accounts = _repo.GetAccounts();
            var model = new CustomerAccountsViewModel();

            foreach (var customer in customers)
            {
                var customerAccount = new CustomerAccount
                {
                    Accounts = accounts.Where(x => x.CustomerID == customer.CustomerID),
                    Customer = customer
                };

                model.CustomerAccounts.Add(customerAccount);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
