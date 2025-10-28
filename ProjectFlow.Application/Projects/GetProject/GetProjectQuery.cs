using ProjectFlow.Application.Abstractions.Messaging;

namespace ProjectFlow.Application.Projects.GetProject;

public sealed record GetProjectQuery(Guid Id) : IQuery<ProjectResponse>;