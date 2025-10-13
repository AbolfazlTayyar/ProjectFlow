using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Task.Events;

public record TaskStartedDomainEvent(Guid Id) : IDomainEvent;