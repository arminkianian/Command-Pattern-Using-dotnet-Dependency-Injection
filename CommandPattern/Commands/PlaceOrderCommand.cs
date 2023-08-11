using CommandPattern.Framework;

namespace CommandPattern.Commands
{
    public record PlaceOrderCommand(int CustomerId) : ICommand
    {
    }
}
