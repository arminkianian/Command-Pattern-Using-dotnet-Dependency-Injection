using CommandPattern.Commands;
using CommandPattern.Framework;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var bus = serviceProvider.GetService<ICommandBus>();

            var placeOrderCommand = new PlaceOrderCommand(1);
            bus.Dispatch(placeOrderCommand);

            var submitCustomerCommand = new SubmitCustomerCommand("Armin");
            bus.Dispatch(submitCustomerCommand);
        }

    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var commandHandlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)));

        foreach (var handlerType in commandHandlerTypes)
        {
            var handlerInterfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

            foreach (var handlerInterface in handlerInterfaces)
            {
                services.AddScoped(handlerInterface, handlerType);
            }
        }

        services.AddSingleton<ICommandBus, CommandBus>();
    }
}