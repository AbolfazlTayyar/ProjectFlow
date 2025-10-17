using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Application.Projects.CreateProject;

internal sealed class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUserRepository userRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
            return Result.Failure<Guid>(UserErrors.NotFound);

        var project = Project.Create(
            request.UserId,
            request.Name,
            request.Description,
            request.DateRange,
            request.TimeEstimate,
            request.Price,
            request.MaxMemberCount);

        _projectRepository.Add(project);

        await _unitOfWork.SaveChangesAsync();

        return project.Id;
    }
}
