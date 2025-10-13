using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.ProjectMembers.Events;

public record ProjectMemberCreatedDomainEvent(Guid Id) : IDomainEvent;