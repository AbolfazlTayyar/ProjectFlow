namespace ProjectFlow.Domain.Projects;

public record DateRange
{
    public DateTime StartAtUtc { get; }
    public DateTime EndAtUtc { get; }

    public DateRange(DateTime startAtUtc, DateTime endAtUtc)
    {
        if (endAtUtc < startAtUtc)
            throw new ArgumentException("End date must be after start date.");

        StartAtUtc = startAtUtc;
        EndAtUtc = endAtUtc;
    }

    public TimeSpan Duration => EndAtUtc - StartAtUtc;
}