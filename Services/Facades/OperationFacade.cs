using bigHomeWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bigHomeWork.Services.Facades
{
    public class OperationFacade
    {
        private List<Operation> operations = new List<Operation>();

        // Добавление операции
        public void AddOperation(Operation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation), "Операция не может быть null.");
            }

            // Проверка на дубликаты (по ID)
            if (operations.Any(o => o.Id == operation.Id))
            {
                throw new InvalidOperationException("Операция с таким ID уже существует.");
            }

            operations.Add(operation);
        }

        // Редактирование операции
        public void EditOperation(int id, string newType, int newBankAccountId, decimal newAmount, DateTime newDate, string newDescription, int newCategoryId)
        {
            var operation = operations.FirstOrDefault(o => o.Id == id);
            if (operation == null)
            {
                throw new ArgumentException("Операция с указанным ID не найдена.");
            }

            operation.Type = newType;
            operation.BankAccountId = newBankAccountId;
            operation.Amount = newAmount;
            operation.Date = newDate;
            operation.Description = newDescription;
            operation.CategoryId = newCategoryId;
        }

        // Удаление операции
        public void DeleteOperation(int id)
        {
            var operation = operations.FirstOrDefault(o => o.Id == id);
            if (operation == null)
            {
                throw new ArgumentException("Операция с указанным ID не найдена.");
            }

            operations.Remove(operation);
        }

        // Получение операции по ID
        public Operation GetOperationById(int id)
        {
            var operation = operations.FirstOrDefault(o => o.Id == id);
            if (operation == null)
            {
                throw new ArgumentException("Операция с указанным ID не найдена.");
            }

            return operation;
        }

        // Получение всех операций
        public List<Operation> GetAllOperations()
        {
            return operations;
        }

        // Получение операций по счету
        public List<Operation> GetOperationsByBankAccountId(int bankAccountId)
        {
            return operations.Where(o => o.BankAccountId == bankAccountId).ToList();
        }

        // Получение операций по категории
        public List<Operation> GetOperationsByCategoryId(int categoryId)
        {
            return operations.Where(o => o.CategoryId == categoryId).ToList();
        }

        // Расчет разницы между доходами и расходами за период
        public decimal CalculateIncomeExpenseDifference(DateTime startDate, DateTime endDate)
        {
            var income = operations
                .Where(o => o.Type == "Income" && o.Date >= startDate && o.Date <= endDate)
                .Sum(o => o.Amount);

            var expense = operations
                .Where(o => o.Type == "Expense" && o.Date >= startDate && o.Date <= endDate)
                .Sum(o => o.Amount);

            return income - expense;
        }

        // Пересчет баланса счета
        public decimal CalculateBalance(int bankAccountId)
        {
            return operations
                .Where(o => o.BankAccountId == bankAccountId)
                .Sum(o => o.Type == "Income" ? o.Amount : -o.Amount);
        }
    }
}