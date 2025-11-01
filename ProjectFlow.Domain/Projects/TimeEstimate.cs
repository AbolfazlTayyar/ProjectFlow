namespace ProjectFlow.Domain.Projects;

public record TimeEstimate
{
    public int EstimatedHours { get; init; }

    private TimeEstimate(int estimatedHours)
    {
        if (estimatedHours < 0)
            throw new ArgumentException("Estimated time cannot be negative.");

        EstimatedHours = estimatedHours;
    }

    public static TimeEstimate Create(int estimatedHours)
    {
        return new TimeEstimate(estimatedHours);
    }

    public override string ToString() => $"{EstimatedHours}h";
}