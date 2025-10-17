using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Projects.Events;

public record ProjectCreatedDomainEvent(Guid ProjectId) : IDomainEvent;
