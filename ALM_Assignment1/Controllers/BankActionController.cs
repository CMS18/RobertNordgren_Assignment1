using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM_Assignment1.Models;
using BankApp.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.UI.Controllers
{
    public class BankActionsController : Controller
    {
        private readonly IBankRepository repository;

        public BankActionsController(IBankRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Actions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(WithdrawDepositViewModel model)
        {
            var validAccount = int.TryParse(model.AccountID, out int accountid);
            var validAmount = decimal.TryParse(model.Amount, out decimal result);

            if(validAccount && validAmount)
            {
                var account = repository.GetAccounts(accountid);
                if (account != null)
                {
                    repository.Deposit(account, result);
                    TempData["Success"] = "Amount deposited!";
                } else
                {
                    TempData["Error"] = "Incorrect account number";
                }
            } else
            {
                TempData["Error"] = "Invalid input";
            }

            return RedirectToAction("Actions"); 
        }

        [HttpPost]
        public IActionResult Withdraw(WithdrawDepositViewModel model)
        {
            var validAccount = int.TryParse(model.AccountID, out int accountid);
            var validAmount = decimal.TryParse(model.Amount, out decimal result);

            if (validAccount && validAmount)
            {
                var account = repository.GetAccounts(accountid);
                if (account != null)
                {
                    repository.Withdraw(account, result);
                    TempData["Success"] = "Amount withdrawn!";
                }
                else
                {
                    TempData["Error"] = "Incorrect account number";
                }
            }
            else
            {
                TempData["Error"] = "Invalid input";
            }

            return RedirectToAction("Actions");
        }
    }
}