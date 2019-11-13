using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Assignment1.Models
{
    public interface IBankRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Account> GetAccounts();
    }

    public class BankRepository : IBankRepository
    {
        public static IEnumerable<Customer> Customers = new List<Customer>
        {
            new Customer { CustomerID = 1, Name = "Steve Tabernackle" },
            new Customer { CustomerID = 2, Name = "Sarah Andrews" },
            new Customer { CustomerID = 3, Name = "Donna Carter" },
        };

        public IEnumerable<Account> Accounts = new List<Account>
        {
            new Account { AccountID = 1, CustomerID = 1, Balance = 25543M },
            new Account { AccountID = 2, CustomerID = 2, Balance = 8403M },
            new Account { AccountID = 3, CustomerID = 3, Balance = 323M },
            new Account { AccountID = 4, CustomerID = 1, Balance = 4235662M },
            new Account { AccountID = 5, CustomerID = 2, Balance = 47034M },
        };

        public IEnumerable<Account> GetAccounts()
        {
            return Accounts;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Customers;
        }
    }
}
