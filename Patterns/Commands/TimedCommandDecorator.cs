using System.Diagnostics;

namespace bigHomeWork.Patterns.Commands
{
    public class TimedCommandDecorator : ICommand
    {
        private ICommand command;

        public TimedCommandDecorator(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            command.Execute();
            stopwatch.Stop();
            Console.WriteLine($"Команда выполнена за {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}