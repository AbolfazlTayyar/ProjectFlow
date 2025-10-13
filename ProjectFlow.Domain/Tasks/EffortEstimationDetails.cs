namespace ProjectFlow.Domain.Task;

public record EffortEstimationDetails(
    int BaseHours,
    decimal AdjustedHours,
    DateTime EstimatedDueDate);