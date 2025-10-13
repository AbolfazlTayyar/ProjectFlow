using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Projects.Events;

public record ProjectCreatedDomainEvent(Guid Id) : IDomainEvent;
