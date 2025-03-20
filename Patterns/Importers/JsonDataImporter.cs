using System.IO;

namespace bigHomeWork.Patterns.Importers
{
    public abstract class DataImporter
    {
        public void ImportData(string filePath)
        {
            var data = ReadData(filePath);
            ProcessData(data);
        }

        protected abstract string ReadData(string filePath);
        protected abstract void ProcessData(string data);
    }

    public class JsonDataImporter : DataImporter
    {
        protected override string ReadData(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        protected override void ProcessData(string data)
        {
            Console.WriteLine("Processing JSON data");
        }
    }
}