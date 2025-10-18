using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }
}
