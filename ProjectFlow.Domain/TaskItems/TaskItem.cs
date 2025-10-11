using ProjectFlow.Domain.Abstracts;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.TaskItems.Events;

namespace ProjectFlow.Domain.TaskItems;

public sealed class TaskItem : Entity
{
    public TaskItem(
        Guid id,
        Guid projectId,
        Guid assigneeId,
        Title title,
        Description description,
        EffortEstimationDetails effort,
        TaskItemStatus status,
        TaskItemPriority priority,
        TaskItemComplexity complexity,
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
    public TaskItemStatus Status { get; private set; }
    public TaskItemPriority Priority { get; private set; }
    public TaskItemComplexity Complexity { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? DueDateOnUtc { get; private set; }

    public static TaskItem Create(
        Project Project,
        Guid AssigneeId,
        Title title,
        Description description,
        EstimateEffortService estimateEffortService,
        TaskItemPriority priority,
        TaskItemComplexity complexity,
        DateTime utcNow)
    {
        var effort = estimateEffortService.EstimateEffort(complexity, priority);

        var taskItem = new TaskItem(
            Guid.NewGuid(),
            Project.Id,
            AssigneeId,
            title,
            description,
            effort,
            TaskItemStatus.ToDo,
            priority,
            complexity,
            utcNow);

        taskItem.RaiseDomainEvent(new TaskItemCreatedDomainEvent(taskItem.Id));

        return taskItem;
    }
}
