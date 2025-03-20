using System.IO;
using System.Reflection;

public static class SolutionPathHelper
{
    public static string GetSolutionDirectory()
    {
        // Получаем путь к исполняемому файлу
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;

        // Получаем директорию, в которой находится исполняемый файл
        var assemblyDirectory = Path.GetDirectoryName(assemblyLocation);

        // Поднимаемся на три уровня вверх (из bin/Debug/netX.X в папку решения)
        var solutionDirectory = Path.GetFullPath(Path.Combine(assemblyDirectory, "../../.."));

        return solutionDirectory;
    }
}