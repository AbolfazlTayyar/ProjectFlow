using ProjectFlow.Application.Abstractions.Clock;
using ProjectFlow.Application.Abstractions.Data;
using ProjectFlow.Application.Abstractions.Email;
using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.ProjectMembers;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;
using ProjectFlow.Infrastructure.Clock;
using ProjectFlow.Infrastructure.Data;
using ProjectFlow.Infrastructure.Email;
using ProjectFlow.Infrastructure.Repositories;

namespace ProjectFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectMemberRepository, ProjectMemberRepository>();
        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
