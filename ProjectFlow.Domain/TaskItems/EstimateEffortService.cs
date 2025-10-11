namespace ProjectFlow.Domain.TaskItems;

public class EstimateEffortService
{
    public EffortEstimationDetails EstimateEffort(TaskItemComplexity complexity, TaskItemPriority priority)
    {
        var baseHours = complexity switch
        {
            TaskItemComplexity.Low => 4,
            TaskItemComplexity.Medium => 8,
            TaskItemComplexity.High => 16,
        };

        var priorityFactor = priority switch
        {
            TaskItemPriority.Low => 1.2m,
            TaskItemPriority.Medium => 1.0m,
            TaskItemPriority.High => 0.8m,
        };

        var adjustedHours = baseHours * priorityFactor;
        var dueDate = DateTime.UtcNow.AddHours((double)adjustedHours);

        return new EffortEstimationDetails(baseHours, adjustedHours, dueDate);
    }
}
