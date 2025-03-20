using bigHomeWork.Domain;

namespace bigHomeWork.Patterns.Commands
{
    public class CreateOperationCommand : ICommand
    {
        private Operation operation;
        private List<Operation> operations;

        public CreateOperationCommand(Operation operation, List<Operation> operations)
        {
            this.operation = operation;
            this.operations = operations;
        }

        public void Execute()
        {
            operations.Add(operation);
        }
    }
}