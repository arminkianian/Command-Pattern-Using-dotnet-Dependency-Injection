namespace CommandPattern.Framework
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
