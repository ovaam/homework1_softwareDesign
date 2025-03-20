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

        public void EditBankAccount(int id, string newName, decimal newBalance)
        {
            var account = bankAccounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                account.Name = newName;
                account.Balance = newBalance;
            }
        }

        public void DeleteBankAccount(int id)
        {
            var account = bankAccounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                bankAccounts.Remove(account);
            }
        }

        public List<BankAccount> GetBankAccounts()
        {
            return bankAccounts;
        }
    }
}