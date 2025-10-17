using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.Projects;

namespace ProjectFlow.Application.Projects.CreateProject;

public record CreateProjectCommand(
    Guid UserId,
    Name Name,
    Description Description,
    DateRange DateRange,
    TimeEstimate TimeEstimate,
    Money Price,
    int MaxMemberCount) : ICommand<Guid>;
