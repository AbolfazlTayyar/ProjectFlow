using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
