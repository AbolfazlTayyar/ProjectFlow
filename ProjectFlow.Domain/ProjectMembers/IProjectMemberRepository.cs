namespace ProjectFlow.Domain.ProjectMembers;

public interface IProjectMemberRepository
{
    Task<ProjectMember> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<ProjectMember>> GetProjectMembersAsync(Guid projectId, CancellationToken cancellationToken = default);
    void Add(ProjectMember projectMember);
}
