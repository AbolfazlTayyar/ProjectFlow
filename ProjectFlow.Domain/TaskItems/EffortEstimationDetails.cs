namespace ProjectFlow.Domain.TaskItems;

public record EffortEstimationDetails(
    int BaseHours,
    decimal AdjustedHours,
    DateTime EstimatedDueDate);