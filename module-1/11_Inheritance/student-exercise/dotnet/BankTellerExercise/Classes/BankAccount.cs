
namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }
        
        // This is the way we are supposed to do this but this is bad. DRY
        public BankAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountNumber;
            AccountNumber = accountNumber;
            Balance = 0;
        }
        public BankAccount(string accountHolderName, string accountNumber, decimal balance)
        {
            AccountHolderName = accountNumber;
            AccountNumber = accountNumber;
            Balance = balance;
        }
        /*
        public BankAccount(string accountHolderName, string accountNumber, decimal balance = 0)
        {
            AccountHolderName = accountNumber;
            AccountNumber = accountNumber;
            Balance = balance; // I don't understand why we didn't talk about default parameters. :/
        }
        */
        public virtual decimal Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            return Balance;
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Balance -= amountToWithdraw;
            return Balance;
        }
        
    }
}
