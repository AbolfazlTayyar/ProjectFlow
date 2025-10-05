using ProjectFlow.Domain.Abstracts;

namespace ProjectFlow.Domain.Projects;

public sealed class Project : Entity
{
    public Project(Guid id,
        Name name,
        Description description,
        DateRange dateRange,
        TimeEstimate timeEstimate,
        Money price)
        : base(id)
    {
        Name = name;
        Description = description;
        DateRange = dateRange;
        TimeEstimate = timeEstimate;
        Price = price;
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public DateRange DateRange { get; private set; }
    public TimeEstimate TimeEstimate { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
}
