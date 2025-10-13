using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
