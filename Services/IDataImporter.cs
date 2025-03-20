using bigHomeWork.Domain;

namespace bigHomeWork.Services
{
    public interface IDataImporter
    {
        List<BankAccount> ImportBankAccounts(string filePath);
        List<Category> ImportCategories(string filePath);
        List<Operation> ImportOperations(string filePath);
    }
}