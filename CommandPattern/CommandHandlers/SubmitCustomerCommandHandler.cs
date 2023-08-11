using CommandPattern.Commands;
using CommandPattern.Framework;

namespace CommandPattern.CommandHandlers
{
    public class SubmitCustomerCommandHandler : ICommandHandler<SubmitCustomerCommand>
    {
        public Task Handle(SubmitCustomerCommand command)
        {
            Console.WriteLine($"Handling {nameof(SubmitCustomerCommand)}");
            return Task.CompletedTask;
        }
    }
}
