namespace ProjectFlow.Domain.Task;

public class EstimateEffortService
{
    public EffortEstimationDetails EstimateEffort(TaskComplexity complexity, TaskPriority priority)
    {
        var baseHours = complexity switch
        {
            TaskComplexity.Low => 4,
            TaskComplexity.Medium => 8,
            TaskComplexity.High => 16,
        };

        var priorityFactor = priority switch
        {
            TaskPriority.Low => 1.2m,
            TaskPriority.Medium => 1.0m,
            TaskPriority.High => 0.8m,
        };

        var adjustedHours = baseHours * priorityFactor;
        var dueDate = DateTime.UtcNow.AddHours((double)adjustedHours);

        return new EffortEstimationDetails(baseHours, adjustedHours, dueDate);
    }
}
