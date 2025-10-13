namespace ProjectFlow.Domain.ProjectMembers;

public interface IProjectMemberRepository
{
    Task<List<ProjectMember>> GetProjectMembersAsync(Guid projectId, CancellationToken cancellationToken = default);
    void Add(ProjectMember projectMember);
}
