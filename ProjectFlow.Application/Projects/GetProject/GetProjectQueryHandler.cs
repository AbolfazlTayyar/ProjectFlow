using Dapper;
using ProjectFlow.Application.Abstractions.Data;
using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Application.Projects.GetProject;

internal sealed class GetProjectQueryHandler : IQueryHandler<GetProjectQuery, ProjectResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetProjectQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<ProjectResponse>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                name AS Name,
                description AS Description,
                estimated_hours AS EstimatedHours,
                currency AS Currency,
                max_member_count AS MaxMemberCount,
                last_member_added_on_utc AS LastMemberAddedOnUtc
            FROM projects
            WHERE id = @Id
            """;

        var project = await connection.QueryFirstOrDefaultAsync<ProjectResponse>(
            sql,
            new
            {
                request.Id
            });

        if (project is null)
        {
            return Result.Failure<ProjectResponse>(new Error(
                "Project.NotFound",
                "The project with the specified ID was not found"));
        }

        return Result.Success(project);
    }
}
