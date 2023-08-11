using CommandPattern.CommandHandlers;

namespace CommandPattern.Framework
{
    public class DemoCommandBus : ICommandBus
    {
        private readonly List<object> _handlers;

        public DemoCommandBus()
        {
            _handlers = new List<object>
            {
                new SubmitCustomerCommandHandler(),
                new PlaceOrderCommandHandler()
            };
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            var candidates = _handlers.OfType<ICommandHandler<T>>().ToList();

            foreach (var handler in candidates)
            {
                await handler.Handle(command);
            }
        }
    }
}
