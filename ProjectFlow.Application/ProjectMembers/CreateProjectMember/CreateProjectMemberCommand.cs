using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.ProjectMembers;

namespace ProjectFlow.Application.ProjectMembers.CreateProjectMember;

public record CreateProjectMemberCommand(
    Guid UserId,
    Guid ProjectId,
    ProjectMemberRole Role,
    ProjectMemberExperienceLevel ExperienceLevel) : ICommand<Guid>;
