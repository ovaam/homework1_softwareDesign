using bigHomeWork.Domain;

namespace bigHomeWork.Services.Facades
{
    public class OperationFacade
    {
        private List<Operation> operations = new List<Operation>();

        public void AddOperation(Operation operation)
        {
            operations.Add(operation);
        }

        public decimal CalculateIncomeExpenseDifference(DateTime startDate, DateTime endDate)
        {
            var income = operations.Where(o => o.Type == "Income" && o.Date >= startDate && o.Date <= endDate).Sum(o => o.Amount);
            var expense = operations.Where(o => o.Type == "Expense" && o.Date >= startDate && o.Date <= endDate).Sum(o => o.Amount);
            return income - expense;
        }

        public decimal CalculateBalance(int bankAccountId)
        {
            return operations.Where(o => o.BankAccountId == bankAccountId).Sum(o => o.Type == "Income" ? o.Amount : -o.Amount);
        }
    }
}