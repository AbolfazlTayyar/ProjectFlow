using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Application.Exceptions;
using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.Apartments;
using ProjectFlow.Domain.ProjectMembers;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Application.ProjectMembers.CreateProjectMember;

internal sealed class CreateProjectMemberCommandHandler : ICommandHandler<CreateProjectMemberCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectMemberRepository _projectMemberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectMemberCommandHandler(IUserRepository userRepository,
        IProjectRepository projectRepository,
        IProjectMemberRepository projectMemberRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _projectMemberRepository = projectMemberRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        var project = await _projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);
        if (project is null)
            return Result.Failure<Guid>(ProjectErrors.NotFound);

        var projectMembers = await _projectMemberRepository.GetProjectMembersAsync(request.ProjectId, cancellationToken);
        if (projectMembers.Count >= project.MaxMemberCount)
            return Result.Failure<Guid>(ProjectErrors.MaxMemberLimitReached);

        try
        {
            var projectMember = ProjectMember.Create(
                    user.Id,
                    project.Id,
                    request.Role,
                    request.ExperienceLevel,
                    project);

            _projectMemberRepository.Add(projectMember);

            await _unitOfWork.SaveChangesAsync();

            return projectMember.Id;
        }
        catch (ConcurrencyException ex)
        {
            return Result.Failure<Guid>(ProjectErrors.MaxMemberLimitReached);
        }
    }
}
