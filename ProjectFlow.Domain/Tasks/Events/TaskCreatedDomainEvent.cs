using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Task.Events;

public record TaskCreatedDomainEvent(Guid Id) : IDomainEvent;
