namespace ProjectFlow.Application.Tasks.GetTask;

public sealed class TaskResponse
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public Guid AssigneeId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Effort { get; init; }
    public int Status { get; init; }
    public int Priority { get; init; }
    public int Complexity { get; init; }
    public DateTime CreatedOnUtc { get; init; }
    public DateTime StartedOnUtc { get; init; }
    public DateTime? DueDateOnUtc { get; init; }
}
