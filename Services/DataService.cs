using bigHomeWork.Domain;

namespace bigHomeWork.Services
{
    public interface IDataService
    {
        List<BankAccount> GetBankAccounts();
        List<Category> GetCategories();
        List<Operation> GetOperations();
    }

    public class DataService : IDataService
    {
        public List<BankAccount> GetBankAccounts()
        {
            // Реализация получения данных из БД
            return new List<BankAccount>();
        }

        public List<Category> GetCategories()
        {
            // Реализация получения данных из БД
            return new List<Category>();
        }

        public List<Operation> GetOperations()
        {
            // Реализация получения данных из БД
            return new List<Operation>();
        }
    }
}