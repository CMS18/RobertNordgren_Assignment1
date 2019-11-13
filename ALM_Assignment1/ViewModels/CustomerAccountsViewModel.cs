using ALM_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Assignment1.ViewModels
{
    public class CustomerAccountsViewModel
    {
        public List<CustomerAccount> CustomerAccounts { get; set; }

        public CustomerAccountsViewModel()
        {
            CustomerAccounts = new List<CustomerAccount>();
        }
    }

    public class CustomerAccount
    {
        public Customer Customer { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
