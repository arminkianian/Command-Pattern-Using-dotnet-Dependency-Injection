using CommandPattern.Commands;
using CommandPattern.Framework;

namespace CommandPattern.CommandHandlers
{
    public class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand>
    {
        public Task Handle(PlaceOrderCommand command)
        {
            Console.WriteLine($"Handling {nameof(PlaceOrderCommand)}");
            return Task.CompletedTask;
        }
    }
}
