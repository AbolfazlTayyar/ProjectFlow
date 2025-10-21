namespace ProjectFlow.Domain.Projects;

public record TimeEstimate
{
    public int EstimatedHours { get; }

    public TimeEstimate(int hours)
    {
        if (hours < 0)
            throw new ArgumentException("Estimated time cannot be negative.");
        EstimatedHours = hours;
    }

    public override string ToString() => $"{EstimatedHours}h";
}

