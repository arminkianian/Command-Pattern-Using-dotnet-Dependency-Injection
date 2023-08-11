using CommandPattern.Framework;

namespace CommandPattern.Commands
{
    public record SubmitCustomerCommand(string Name) : ICommand
    {
    }
}
