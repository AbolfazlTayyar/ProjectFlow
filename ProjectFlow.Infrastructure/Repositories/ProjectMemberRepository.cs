using ProjectFlow.Domain.ProjectMembers;

namespace ProjectFlow.Infrastructure.Repositories;

internal sealed class ProjectMemberRepository : Repository<ProjectMember>, IProjectMemberRepository
{
    public ProjectMemberRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public Task<List<ProjectMember>> GetProjectMembersAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var projectMembers = DbContext.Set<ProjectMember>()
            .Where(x => x.ProjectId == projectId)
            .ToListAsync(cancellationToken);

        return projectMembers;
    }
}
