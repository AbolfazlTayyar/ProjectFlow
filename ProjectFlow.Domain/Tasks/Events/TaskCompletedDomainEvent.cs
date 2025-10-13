using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Task.Events;
public record TaskCompletedDomainEvent(Guid Id) : IDomainEvent;
