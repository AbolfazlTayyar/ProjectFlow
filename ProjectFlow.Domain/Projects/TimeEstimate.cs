namespace ProjectFlow.Domain.Projects;

public record TimeEstimate
{
    public int EstimatedHours { get; init; }

    public TimeEstimate(int estimatedHours)
    {
        if (estimatedHours < 0)
            throw new ArgumentException("Estimated time cannot be negative.");

        EstimatedHours = estimatedHours;
    }

    public override string ToString() => $"{EstimatedHours}h";
}