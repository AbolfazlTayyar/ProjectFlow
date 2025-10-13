using ProjectFlow.Application.Abstractions.Email;
using ProjectFlow.Domain.ProjectMembers;
using ProjectFlow.Domain.ProjectMembers.Events;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Application.ProjectMembers.CreateProjectMember;

internal sealed class ProjectMemberCreatedDomainEventHandler : INotificationHandler<ProjectMemberCreatedDomainEvent>
{
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IEmailService _emailService;

    public ProjectMemberCreatedDomainEventHandler(IProjectMemberRepository projectMemberRepository,
        IUserRepository userRepository,
        IProjectRepository projectRepository,
        IEmailService emailService)
    {
        _projectMemberRepository = projectMemberRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _emailService = emailService;
    }

    public async Task Handle(ProjectMemberCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var projectMember = await _projectMemberRepository.GetByIdAsync(notification.ProjectMemberId);
        if (projectMember is null)
            return;

        var user = await _userRepository.GetByIdAsync(projectMember.UserId, cancellationToken);
        if (user is null)
            return;

        var project = await _projectRepository.GetByIdAsync(projectMember.ProjectId, cancellationToken);
        if (project is null)
            return;

        await _emailService.SendAsync(
            user.Email,
            "You've been added to a new project",
            $"Hello {user.FirstName} {user.LastName},\n\nYou have been added to the project \"{project.Name}\".\n\nBest regards,\nThe Team");
    }
}
