namespace _Project.Application.Commands
{
    public class CommandProcessor
    {
        public void ExecuteCommand(ICommand command)
        {
            if (command.IsValid())
            {
                command.Execute();
            }
        }
    }
}