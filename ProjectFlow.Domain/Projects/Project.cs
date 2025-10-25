using ProjectFlow.Domain.Abstractions;
using ProjectFlow.Domain.Projects.Events;

namespace ProjectFlow.Domain.Projects;

public sealed class Project : Entity
{
    public Project(
        Guid id,
        Guid createdByUserId,
        Name name,
        Description description,
        DateRange dateRange,
        TimeEstimate timeEstimate,
        Money price,
        int maxMemberCount)
        : base(id)
    {
        CreatedByUserId = createdByUserId;
        Name = name;
        Description = description;
        DateRange = dateRange;
        TimeEstimate = timeEstimate;
        Price = price;
        MaxMemberCount = maxMemberCount;
    }

    public Guid CreatedByUserId { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public DateRange DateRange { get; private set; }
    public TimeEstimate TimeEstimate { get; private set; }
    public Money Price { get; private set; }
    public int MaxMemberCount { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? LastMemberAddedOnUtc { get; internal set; }

    public static Project Create(Guid CreatedByUserId, Name name, Description description, DateRange dateRange, TimeEstimate timeEstimate, Money price, int maxMemberCount)
    {
        Project project = new(Guid.NewGuid(), CreatedByUserId, name, description, dateRange, timeEstimate, price, maxMemberCount);
        project.CreatedOnUtc = DateTime.UtcNow;

        project.RaiseDomainEvent(new ProjectCreatedDomainEvent(project.Id));

        return project;
    }
}
