using Microsoft.Extensions.DependencyInjection;

namespace CommandPattern.Framework
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}
