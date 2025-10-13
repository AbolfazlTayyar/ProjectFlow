using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Task.Events;

namespace ProjectFlow.Domain.Task;

public sealed class Task : Entity
{
    public Task(
        Guid id,
        Guid projectId,
        Guid assigneeId,
        Title title,
        Description description,
        EffortEstimationDetails effort,
        TaskStatus status,
        TaskPriority priority,
        TaskComplexity complexity,
        DateTime createdOnUtc)
        : base(id)
    {
        ProjectId = projectId;
        AssigneeId = assigneeId;
        Title = title;
        Description = description;
        Status = status;
        Complexity = complexity;
        CreatedOnUtc = createdOnUtc;
    }

    public Guid ProjectId { get; private set; }
    public Guid AssigneeId { get; private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public EffortEstimationDetails Effort { get; private set; }
    public TaskStatus Status { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskComplexity Complexity { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime StartedOnUtc { get; private set; }
    public DateTime? DueDateOnUtc { get; private set; }

    public static Task Create(
        Project Project,
        Guid AssigneeId,
        Title title,
        Description description,
        EstimateEffortService estimateEffortService,
        TaskPriority priority,
        TaskComplexity complexity,
        DateTime utcNow)
    {
        var effort = estimateEffortService.EstimateEffort(complexity, priority);

        var task = new Task(
            Guid.NewGuid(),
            Project.Id,
            AssigneeId,
            title,
            description,
            effort,
            TaskStatus.ToDo,
            priority,
            complexity,
            utcNow);

        task.RaiseDomainEvent(new TaskCreatedDomainEvent(task.Id));

        return task;
    }

    public Result Start(DateTime utcNow)
    {
        if (Status != TaskStatus.ToDo)
            return Result.Failure(TaskErrors.NotInTodoState);

        Status = TaskStatus.InProgress;
        StartedOnUtc = utcNow;

        RaiseDomainEvent(new TaskStartedDomainEvent(Id));

        return Result.Success();
    }

    public Result Complete(DateTime utcNow)
    {
        if (Status != TaskStatus.InProgress)
            return Result.Failure(TaskErrors.CannotCompleteFromCurrentState);

        Status = TaskStatus.Done;
        DueDateOnUtc = utcNow;

        RaiseDomainEvent(new TaskCompletedDomainEvent(Id));

        return Result.Success();
    }
}
