namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {
        }

        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {
        }
        public override decimal Withdraw(decimal amountToWithdraw)
        {
            decimal newBal = Balance - amountToWithdraw;
            if (newBal < 0 && newBal > -100)
                newBal -= 10;
            if (newBal <= -100)
                return Balance;
            Balance = newBal;
            return newBal;
        }
    }
}
