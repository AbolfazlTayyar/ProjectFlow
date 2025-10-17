using ProjectFlow.Application.Abstractions.Email;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Projects.Events;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Application.Projects.CreateProject;

internal sealed class ProjectCreatedDomainEventHandler :
    INotificationHandler<ProjectCreatedDomainEvent>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;

    public ProjectCreatedDomainEventHandler(IProjectRepository projectRepository,
        IEmailService emailService,
        IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _emailService = emailService;
        _userRepository = userRepository;
    }

    public async Task Handle(ProjectCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(notification.ProjectId, cancellationToken);
        if (project is null)
            return;

        var user = await _userRepository.GetByIdAsync(project.CreatedByUserId, cancellationToken);
        if (user is null)
            return;

        //send email to project creator
        await _emailService.SendAsync(
            user.Email,
            "A new project has been created by you!",
            $"Hello {user.FirstName} {user.LastName},\n\nA new project has been created by you! \"{project.Name}\".");
    }
}
