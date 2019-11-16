using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALM_Assignment1.Data
{
    public class InsufficientFundsException : Exception
    {
        private static readonly string DefaultMessage = "Insufficient funds available to complete withdraw";

        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(decimal amount) : base(DefaultMessage)
        {
        }
    }
}
