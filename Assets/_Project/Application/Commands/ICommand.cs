namespace _Project.Application.Commands
{
    public interface ICommand
    {
        bool IsValid();
        void Execute();
    }
}