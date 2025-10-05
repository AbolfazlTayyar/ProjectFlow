namespace ProjectFlow.Domain.Project;

public record TimeEstimate
{
    public int Hours { get; }

    public TimeEstimate(int hours)
    {
        if (hours < 0)
            throw new ArgumentException("Estimated time cannot be negative.");
        Hours = hours;
    }

    public override string ToString() => $"{Hours}h";
}

