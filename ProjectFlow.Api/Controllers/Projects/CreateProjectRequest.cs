namespace ProjectFlow.Api.Controllers.Projects;

public record CreateProjectRequest(
    Guid UserId,
    string Name,
    string Description,
    DateOnly StartDate,
    DateOnly EndDate,
    int EstimatedHours,
    decimal Amount,
    string Code,
    int MaxMemberCount);
