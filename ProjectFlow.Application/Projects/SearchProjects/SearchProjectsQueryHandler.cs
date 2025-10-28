using Dapper;
using ProjectFlow.Application.Abstractions.Data;
using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Application.Projects.SearchProjects;

internal sealed class SearchProjectsQueryHandler : IQueryHandler<SearchProjectsQuery, IReadOnlyList<ProjectResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchProjectsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ProjectResponse>>> Handle(SearchProjectsQuery request, CancellationToken cancellationToken)
    {
        if (request.EndDate > request.StartDate)
            return new List<ProjectResponse>();

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                p.id AS Id,
                p.name AS Name,
                p.description AS Description,
                p.estimated_hours AS EstimatedHours,
                p.currency AS Currency,
                p.max_member_count AS MaxMemberCount,
                p.last_member_added_on_utc AS LastMemberAddedOnUtc
            FROM projects AS p
            WHERE p.created_date BETWEEN @StartDate AND @EndDate
            ORDER BY p.created_date DESC
            """;

        var projects = await connection.QueryAsync<ProjectResponse>(
            sql,
            new
            {
                request.StartDate,
                request.EndDate
            });

        return projects.ToList();
    }
}
