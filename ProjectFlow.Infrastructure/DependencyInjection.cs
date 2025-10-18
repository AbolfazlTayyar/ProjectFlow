using ProjectFlow.Application.Abstractions.Clock;
using ProjectFlow.Application.Abstractions.Email;
using ProjectFlow.Infrastructure.Clock;
using ProjectFlow.Infrastructure.Email;

namespace ProjectFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
