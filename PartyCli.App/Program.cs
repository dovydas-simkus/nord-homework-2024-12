using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PartyCli.NordVpnClient;
using PartyCli.Persistence;
using PartyCli.Services;
using PartyCli.Services.Commands;

namespace PartyCli.App;

internal static class Program
{
    public static Task<int> Main(string[] args)
    {
        var services = new ServiceCollection();

        services.RegisterNordVpnClient();
        services.RegisterServices();
        services.RegisterPersistence();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CliCommand>());

        var serviceProvider = services.BuildServiceProvider();

        var mediator = serviceProvider.GetRequiredService<IMediator>();

        return mediator.Send(new CliCommand(args));
    }
}
