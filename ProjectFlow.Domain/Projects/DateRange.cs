namespace ProjectFlow.Domain.Projects;

public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }

    public int LengthInDays => EndDate.DayNumber - StartDate.DayNumber;

    public static DateRange Create(DateOnly startDate, DateOnly endDate)
    {
        if (endDate <= startDate)
            throw new ArgumentException("End date must be after start date.");

        return new DateRange
        {
            StartDate = startDate,
            EndDate = endDate
        };
    }
}