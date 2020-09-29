using System.Collections.Generic;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        private readonly List<IAccountable> _accountables = new List<IAccountable>();

        public bool IsVip
        {
            get
            {
                int totalBalance = 0;
                foreach (IAccountable accountable in _accountables)
                    totalBalance += accountable.Balance;
                return totalBalance >= 25000;
            }
        }


        public void AddAccount(IAccountable newAccount)
        {
            _accountables.Add(newAccount);
        }

        public IAccountable[] GetAccounts()
        {
            return _accountables.ToArray();
        }

    }
}