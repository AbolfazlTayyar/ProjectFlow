using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.TaskItems.Events;

public record TaskItemCreatedDomainEvent(Guid Id) : IDomainEvent;
