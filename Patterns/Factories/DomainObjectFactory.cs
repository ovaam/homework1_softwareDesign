using bigHomeWork.Domain;

namespace bigHomeWork.Patterns.Factories
{
    public class DomainObjectFactory
    {
        public BankAccount CreateBankAccount(int id, string name, decimal balance)
        {
            return new BankAccount { Id = id, Name = name, Balance = balance };
        }

        public Category CreateCategory(int id, string type, string name)
        {
            return new Category { Id = id, Type = type, Name = name };
        }

        public Operation CreateOperation(int id, string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }
            return new Operation { Id = id, Type = type, BankAccountId = bankAccountId, Amount = amount, Date = date, Description = description, CategoryId = categoryId };
        }
    }
}