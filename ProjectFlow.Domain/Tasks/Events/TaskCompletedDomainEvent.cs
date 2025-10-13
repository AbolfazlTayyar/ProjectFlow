using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Task.Events;
public record TaskCompletedDomainEvent(Guid Id) : IDomainEvent;
