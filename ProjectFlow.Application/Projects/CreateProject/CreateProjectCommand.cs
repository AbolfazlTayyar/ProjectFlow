using ProjectFlow.Application.Abstractions.Messaging;

namespace ProjectFlow.Application.Projects.CreateProject;

public record CreateProjectCommand() : ICommand<Guid>;
