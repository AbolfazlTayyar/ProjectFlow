using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.ProjectMembers.Events;

namespace ProjectFlow.Domain.ProjectMembers;

public sealed class ProjectMember : Entity
{
    public ProjectMember(
        Guid id,
        Guid userId,
        Guid projectId,
        ProjectMemberRole role,
        ProjectMemberExperienceLevel experienceLevel)
        : base(id)
    {
        UserId = userId;
        ProjectId = projectId;
        Role = role;
        ExperienceLevel = experienceLevel;
    }

    public Guid UserId { get; private set; }
    public Guid ProjectId { get; private set; }
    public ProjectMemberRole Role { get; private set; }
    public ProjectMemberExperienceLevel ExperienceLevel { get; set; }

    public static ProjectMember Create(Guid userId, Guid projectId, ProjectMemberRole role, ProjectMemberExperienceLevel experienceLevel)
    {
        ProjectMember projectMember = new(Guid.NewGuid(), userId, projectId, role, experienceLevel);

        projectMember.RaiseDomainEvent(new ProjectMemberCreatedDomainEvent(projectMember.Id));

        return projectMember;
    }
}
