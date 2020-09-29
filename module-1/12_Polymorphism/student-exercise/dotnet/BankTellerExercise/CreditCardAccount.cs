namespace BankTellerExercise
{
    public class CreditCardAccount : IAccountable
    {
        public int Balance => Debt * -1;
        public string AccountHolderName { get; }
        public string AccountNumber { get; }
        public int Debt { get; set; } = 0;

        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }

        public int Pay(int amountToPay)
        {
            Debt -= amountToPay;
            return Debt;
        }

        public int Charge(int amountToCharge)
        {
            Debt += amountToCharge;
            return Debt;
        }
        
    }
}