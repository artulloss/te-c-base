namespace BankTellerExercise
{
    public class BankAccount : IAccountable
    {
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; private set; }
        public int Balance { get; private set; }

        public BankAccount(string accountHolder, string accountNumber)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public BankAccount(string accountHolder, string accountNumber, int balance)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int Deposit(int amountToDeposit)
        {
            Balance += amountToDeposit;
            return Balance;
        }

        public virtual int Withdraw(int amountToWithdraw)
        {
            Balance -= amountToWithdraw;
            return Balance;
        }
        // Withdraws transferAmount from this account and deposits it into destinationAccount.
        public virtual int TransferTo(BankAccount destinationAccount, int transferAmount)
        {
            destinationAccount.Balance += transferAmount;
            return Withdraw(transferAmount);
        }
    }
}
