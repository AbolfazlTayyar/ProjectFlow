using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Task.Events;

public record TaskCreatedDomainEvent(Guid Id) : IDomainEvent;
