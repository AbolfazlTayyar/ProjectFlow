using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Comments.Events;

public record CommentCreatedDomainEvent(Guid Id) : IDomainEvent;
