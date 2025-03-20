using bigHomeWork.Domain;
using bigHomeWork.Services;
using bigHomeWork.Services.Facades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace bigHomeWork.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjection.ConfigureServices();

            // Получаем сервисы из контейнера
            var categoryFacade = serviceProvider.GetService<CategoryFacade>();
            var operationFacade = serviceProvider.GetService<OperationFacade>();
            var bankAccountFacade = serviceProvider.GetService<BankAccountFacade>();
            //var jsonDataImporter = serviceProvider.GetService<JsonDataImporter>();

            while (true)
            {
                Console.WriteLine("1. Создать счет");
                Console.WriteLine("2. Редактировать счет");
                Console.WriteLine("3. Удалить счет");
                Console.WriteLine("4. Создать категорию");
                Console.WriteLine("5. Редактировать категорию");
                Console.WriteLine("6. Удалить категорию");
                Console.WriteLine("7. Создать операцию");
                Console.WriteLine("8. Редактировать операцию");
                Console.WriteLine("9. Удалить операцию");
                Console.WriteLine("10. Показать разницу доходов и расходов за период");
                Console.WriteLine("11. Пересчитать баланс");
                Console.WriteLine("12. Выйти");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateBankAccount(bankAccountFacade);
                        break;
                    case "2":
                        EditBankAccount(bankAccountFacade);
                        break;
                    case "3":
                        DeleteBankAccount(bankAccountFacade);
                        break;
                    case "4":
                        CreateCategory(categoryFacade);
                        break;
                    case "5":
                        EditCategory(categoryFacade);
                        break;
                    case "6":
                        DeleteCategory(categoryFacade);
                        break;
                    case "7":
                        CreateOperation(operationFacade);
                        break;
                    case "8":
                        EditOperation(operationFacade);
                        break;
                    case "9":
                        DeleteOperation(operationFacade);
                        break;
                    case "10":
                        ShowIncomeExpenseDifference(operationFacade);
                        break;
                    case "11":
                        RecalculateBalances(bankAccountFacade, operationFacade);
                        break;
                    case "12":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void CreateBankAccount(BankAccountFacade facade)
        {
            Console.Write("Введите ID счета: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите название счета: ");
            var name = Console.ReadLine();
            Console.Write("Введите начальный баланс: ");
            var balance = decimal.Parse(Console.ReadLine());

            var account = new BankAccount { Id = id, Name = name, Balance = balance };
            facade.AddBankAccount(account);
            Console.WriteLine("Счет создан.");
        }

        private static void CreateCategory(CategoryFacade facade)
        {
            Console.Write("Введите ID категории: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите тип категории (Income/Expense): ");
            var type = Console.ReadLine();
            Console.Write("Введите название категории: ");
            var name = Console.ReadLine();

            var category = new Category { Id = id, Type = type, Name = name };
            facade.AddCategory(category);
            Console.WriteLine("Категория создана.");
        }

        private static void CreateOperation(OperationFacade facade)
        {
            Console.Write("Введите ID операции: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите тип операции (Income/Expense): ");
            var type = Console.ReadLine();
            Console.Write("Введите ID счета: ");
            var bankAccountId = int.Parse(Console.ReadLine());
            Console.Write("Введите сумму: ");
            var amount = decimal.Parse(Console.ReadLine());
            Console.Write("Введите дату (yyyy-MM-dd): ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите описание: ");
            var description = Console.ReadLine();
            Console.Write("Введите ID категории: ");
            var categoryId = int.Parse(Console.ReadLine());

            var operation = new Operation { Id = id, Type = type, BankAccountId = bankAccountId, Amount = amount, Date = date, Description = description, CategoryId = categoryId };
            facade.AddOperation(operation);
            Console.WriteLine("Операция создана.");
        }

        private static void EditBankAccount(BankAccountFacade facade)
        {
            Console.Write("Введите ID счета для редактирования: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите новое название счета: ");
            var newName = Console.ReadLine();
            Console.Write("Введите новый баланс: ");
            var newBalance = decimal.Parse(Console.ReadLine());

            facade.EditBankAccount(id, newName, newBalance);
            Console.WriteLine("Счет успешно отредактирован.");
        }

        private static void DeleteBankAccount(BankAccountFacade facade)
        {
            Console.Write("Введите ID счета для удаления: ");
            var id = int.Parse(Console.ReadLine());

            facade.DeleteBankAccount(id);
            Console.WriteLine("Счет успешно удален.");
        }
        
        private static void EditCategory(CategoryFacade facade)
        {
            Console.Write("Введите ID категории для редактирования: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите новый тип категории (Income/Expense): ");
            var newType = Console.ReadLine();
            Console.Write("Введите новое название категории: ");
            var newName = Console.ReadLine();

            facade.EditCategory(id, newType, newName);
            Console.WriteLine("Категория успешно отредактирована.");
        }

        private static void DeleteCategory(CategoryFacade facade)
        {
            Console.Write("Введите ID категории для удаления: ");
            var id = int.Parse(Console.ReadLine());

            facade.DeleteCategory(id);
            Console.WriteLine("Категория успешно удалена.");
        }
        
        private static void EditOperation(OperationFacade facade)
        {
            Console.Write("Введите ID операции для редактирования: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Введите новый тип операции (Income/Expense): ");
            var newType = Console.ReadLine();
            Console.Write("Введите новый ID счета: ");
            var newBankAccountId = int.Parse(Console.ReadLine());
            Console.Write("Введите новую сумму: ");
            var newAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Введите новую дату (yyyy-MM-dd): ");
            var newDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите новое описание: ");
            var newDescription = Console.ReadLine();
            Console.Write("Введите новый ID категории: ");
            var newCategoryId = int.Parse(Console.ReadLine());

            facade.EditOperation(id, newType, newBankAccountId, newAmount, newDate, newDescription, newCategoryId);
            Console.WriteLine("Операция успешно отредактирована.");
        }

        private static void DeleteOperation(OperationFacade facade)
        {
            Console.Write("Введите ID операции для удаления: ");
            var id = int.Parse(Console.ReadLine());

            facade.DeleteOperation(id);
            Console.WriteLine("Операция успешно удалена.");
        }
        
        private static void ShowIncomeExpenseDifference(OperationFacade facade)
        {
            Console.Write("Введите начальную дату (yyyy-MM-dd): ");
            var startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите конечную дату (yyyy-MM-dd): ");
            var endDate = DateTime.Parse(Console.ReadLine());

            var difference = facade.CalculateIncomeExpenseDifference(startDate, endDate);
            Console.WriteLine($"Разница между доходами и расходами за период: {difference}");
        }

        private static void RecalculateBalances(BankAccountFacade bankAccountFacade, OperationFacade operationFacade)
        {
            var accounts = bankAccountFacade.GetBankAccounts();
            foreach (var account in accounts)
            {
                var balance = operationFacade.CalculateBalance(account.Id);
                account.Balance = balance;
                Console.WriteLine($"Баланс счета {account.Id} пересчитан: {balance}");
            }
        }

        private static void ImportData(IDataImporter importer, BankAccountFacade bankAccountFacade, CategoryFacade categoryFacade, OperationFacade operationFacade)
        {
            Console.WriteLine("Что вы хотите импортировать?");
            Console.WriteLine("1. Счета");
            Console.WriteLine("2. Категории");
            Console.WriteLine("3. Операции");
            Console.Write("Выберите тип данных: ");
            var choice = Console.ReadLine();

            Console.Write("Введите имя файла (например, accounts.json): ");
            var fileName = Console.ReadLine();

            try
            {
                // Получаем путь к папке решения
                var solutionDirectory = SolutionPathHelper.GetSolutionDirectory();
                Console.WriteLine($"Папка решения: {solutionDirectory}");

                // Получаем полный путь к файлу в папке решения
                var filePath = Path.Combine(solutionDirectory, fileName);
                Console.WriteLine($"Ищем файл по пути: {filePath}");

                // Проверяем, существует ли файл
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return;
                }

                // Импортируем данные в зависимости от выбора пользователя
                switch (choice)
                {
                    case "1":
                        var accounts = importer.ImportBankAccounts(filePath);
                        if (accounts == null)
                        {
                            Console.WriteLine("Ошибка: файл не содержит данных или данные некорректны.");
                            return;
                        }
                        foreach (var account in accounts)
                        {
                            if (account == null)
                            {
                                Console.WriteLine("Ошибка: один из счетов в файле некорректен.");
                                continue;
                            }
                            bankAccountFacade.AddBankAccount(account);
                        }
                        Console.WriteLine("Счета успешно импортированы.");
                        break;
                    case "2":
                        var categories = importer.ImportCategories(filePath);
                        if (categories == null)
                        {
                            Console.WriteLine("Ошибка: файл не содержит данных или данные некорректны.");
                            return;
                        }
                        foreach (var category in categories)
                        {
                            if (category == null)
                            {
                                Console.WriteLine("Ошибка: одна из категорий в файле некорректна.");
                                continue;
                            }
                            categoryFacade.AddCategory(category);
                        }
                        Console.WriteLine("Категории успешно импортированы.");
                        break;
                    case "3":
                        var operations = importer.ImportOperations(filePath);
                        if (operations == null)
                        {
                            Console.WriteLine("Ошибка: файл не содержит данных или данные некорректны.");
                            return;
                        }
                        foreach (var operation in operations)
                        {
                            if (operation == null)
                            {
                                Console.WriteLine("Ошибка: одна из операций в файле некорректна.");
                                continue;
                            }
                            operationFacade.AddOperation(operation);
                        }
                        Console.WriteLine("Операции успешно импортированы.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка при чтении JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}