using ProjectFlow.Domain.Projects;

namespace ProjectFlow.Infrastructure.Repositories;

internal sealed class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
