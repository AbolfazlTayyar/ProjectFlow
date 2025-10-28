namespace ProjectFlow.Application.Projects;

public class ProjectResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int EstimatedHours { get; init; }
    public string Currency { get; init; }
    public int MaxMemberCount { get; init; }
    public DateTime? LastMemberAddedOnUtc { get; init; }
}