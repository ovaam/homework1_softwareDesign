using bigHomeWork.Domain;

namespace bigHomeWork.Patterns.Visitors
{
    public interface IDataVisitor
    {
        void Visit(BankAccount account);
        void Visit(Category category);
        void Visit(Operation operation);
    }

    public class JsonExportVisitor : IDataVisitor
    {
        public void Visit(BankAccount account)
        {
            Console.WriteLine($"Exporting BankAccount {account.Id} to JSON");
        }

        public void Visit(Category category)
        {
            Console.WriteLine($"Exporting Category {category.Id} to JSON");
        }

        public void Visit(Operation operation)
        {
            Console.WriteLine($"Exporting Operation {operation.Id} to JSON");
        }
    }
}