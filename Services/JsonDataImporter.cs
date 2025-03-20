using bigHomeWork.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace bigHomeWork.Services
{
    public class JsonDataImporter : IDataImporter
    {
        private readonly IDataService _dataService;

        public JsonDataImporter(IDataService dataService)
        {
            _dataService = dataService; // Зависимость от IDataService
        }

        public List<BankAccount> ImportBankAccounts(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<BankAccount>>(json);
        }

        public List<Category> ImportCategories(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Category>>(json);
        }

        public List<Operation> ImportOperations(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Operation>>(json);
        }
    }
}