using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.ProjectMembers.Events;

public record ProjectMemberCreatedDomainEvent(Guid ProjectMemberId) : IDomainEvent;