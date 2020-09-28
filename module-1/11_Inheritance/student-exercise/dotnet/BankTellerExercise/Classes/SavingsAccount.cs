using System;

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {
        }

        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {
        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > Balance || amountToWithdraw + 2 > Balance)
                return Balance;
            Balance -= amountToWithdraw;
            if (Balance < 150)
                Balance -= 2;
            return Balance;
        }
    }
}
