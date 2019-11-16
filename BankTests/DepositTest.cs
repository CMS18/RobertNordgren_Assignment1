using ALM_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankApp.Tests
{
    public class DepositTest
    {
        [Fact]
        public void Deposit()
        {
            // Arrange
            var repo = new BankRepository();
            var account = new Account() { AccountID = 1, Balance = 0 };
            var accountBalance = account.Balance;
            var depositAmount = 1000M;
            var expectedAmount = accountBalance + depositAmount;

            // Act
            repo.Deposit(account, depositAmount);

            // Assert
            Assert.Equal(account.Balance, expectedAmount);
        }
    }
}
