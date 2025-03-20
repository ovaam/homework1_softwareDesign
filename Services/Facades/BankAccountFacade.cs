using bigHomeWork.Domain;

namespace bigHomeWork.Services.Facades
{
    public class BankAccountFacade
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();

        public void AddBankAccount(BankAccount account)
        {
            bankAccounts.Add(account);
        }

        public List<BankAccount> GetBankAccounts()
        {
            return bankAccounts;
        }
    }
}