using ProjectFlow.Domain.Projects;

namespace ProjectFlow.Api.Controllers.Projects;

public record CreateProjectRequest(
    Guid UserId,
    Name Name,
    Description Description,
    DateRange DateRange,
    TimeEstimate TimeEstimate,
    Money Price,
    int MaxMemberCount);
