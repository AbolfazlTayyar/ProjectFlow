using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Task.Events;

public record TaskStartedDomainEvent(Guid Id) : IDomainEvent;