using ALM_Assignment1.Data;
using ALM_Assignment1.Models;
using System;
using System.Linq;
using Xunit;

namespace BankTests
{
    public class WithdrawTest
    {
        [Fact]
        public void WithdrawTooMuch()
        {
            // Arrange
            var repository = new BankRepository();
            var account = new Account { AccountID = 1, Balance = 1000M };

            // Act & Assert
            Assert.Throws<InsufficientFundsException>(() => repository.Withdraw(account, (account.Balance + 1000M)));
        }

        [Fact]
        public void WithdrawNormal()
        {
            // Arrange
            var repository = new BankRepository();
            var account = new Account { AccountID = 1, Balance = 1000M };

            var withdrawAmount = 1000M;
            var accountBalance = account.Balance;
            var expectedAmount = accountBalance -= withdrawAmount;

            repository.Withdraw(account, withdrawAmount);

            // Act & Assert
            Assert.Equal(expectedAmount, account.Balance);
        }
    }
}
