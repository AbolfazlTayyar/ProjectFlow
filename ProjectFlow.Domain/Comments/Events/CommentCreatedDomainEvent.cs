using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Comments.Events;

public record CommentCreatedDomainEvent(Guid Id) : IDomainEvent;
