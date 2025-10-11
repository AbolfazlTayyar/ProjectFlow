using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.ProjectMembers;

public sealed class ProjectMember : Entity
{
    public ProjectMember(Guid id)
        : base(id)
    {
    }

    public Guid UserId { get; private set; }
    public Guid ProjectId { get; private set; }
    public ProjectMemberRole Role { get; private set; }
    public ProjectMemberExperienceLevel ExperienceLevel { get; set; }
}
