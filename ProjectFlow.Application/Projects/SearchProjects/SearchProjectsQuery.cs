using ProjectFlow.Application.Abstractions.Messaging;

namespace ProjectFlow.Application.Projects.SearchProjects;

public sealed record SearchProjectsQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<ProjectResponse>>;