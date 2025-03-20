using bigHomeWork.Domain;

namespace bigHomeWork.Services
{
    public class DataServiceProxy : IDataService
    {
        private IDataService dataService;
        private List<BankAccount> bankAccountsCache;
        private List<Category> categoriesCache;
        private List<Operation> operationsCache;

        public DataServiceProxy(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public List<BankAccount> GetBankAccounts()
        {
            if (bankAccountsCache == null)
            {
                bankAccountsCache = dataService.GetBankAccounts();
            }
            return bankAccountsCache;
        }

        public List<Category> GetCategories()
        {
            if (categoriesCache == null)
            {
                categoriesCache = dataService.GetCategories();
            }
            return categoriesCache;
        }

        public List<Operation> GetOperations()
        {
            if (operationsCache == null)
            {
                operationsCache = dataService.GetOperations();
            }
            return operationsCache;
        }
    }
}