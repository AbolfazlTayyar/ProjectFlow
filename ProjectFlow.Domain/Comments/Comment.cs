using ProjectFlow.Domain.Abstracts;
using ProjectFlow.Domain.Comments.Events;

namespace ProjectFlow.Domain.Comments;

public sealed class Comment : Entity
{
    public Comment(
        Guid id,
        Guid taskId,
        Guid userId,
        Note note,
        Guid assigneeId)
        : base(id)
    {
        TaskId = taskId;
        UserId = userId;
        Note = note;
        AssigneeId = assigneeId;
    }

    public Guid TaskId { get; private set; }
    public Guid UserId { get; private set; }
    public Note Note { get; private set; }
    public Guid AssigneeId { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static Comment Create(Guid taskId, Guid userId, Note note, Guid assigneeId)
    {
        Comment comment = new(Guid.NewGuid(), taskId, userId, note, assigneeId);
        comment.CreatedOnUtc = DateTime.UtcNow;

        comment.RaiseDomainEvent(new CommentCreatedDomainEvent(comment.Id));

        return comment;
    }
}
