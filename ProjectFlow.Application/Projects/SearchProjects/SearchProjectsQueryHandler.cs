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
        if (request.StartDate > request.EndDate)
            return new List<ProjectResponse>();

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                p.id AS Id,
                p.name AS Name,
                p.description AS Description,
                p.time_estimate_estimated_hours AS EstimatedHours,
                p.price_amount AS Price,
                p.price_currency AS Currency,
                p.max_member_count AS MaxMemberCount,
                p.created_on_utc AS CreatedOnUtc,
                p.last_member_added_on_utc AS LastMemberAddedOnUtc
            FROM projects AS p
            WHERE p.created_on_utc BETWEEN @StartDate AND @EndDate
            ORDER BY p.created_on_utc DESC
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
