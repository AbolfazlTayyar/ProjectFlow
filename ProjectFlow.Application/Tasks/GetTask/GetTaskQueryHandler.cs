using Dapper;
using ProjectFlow.Application.Abstractions.Data;
using ProjectFlow.Application.Abstractions.Messaging;
using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Application.Tasks.GetTask;

internal sealed class GetTaskQueryHandler : IQueryHandler<GetTaskQuery, TaskResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetTaskQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<TaskResponse>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                id AS Id,
                project_id AS ProjectId,
                assignee_id AS AssigneeId,
                title AS Title,
                description AS Description,
                effort AS Effort,
                status AS Status,
                priority AS Priority,
                complexity AS Complexity,
                created_on_utc AS CreatedOnUtc,
                started_on_utc AS StartedOnUtc,
                due_date_on_utc AS DueDateOnUtc
            FROM tasks
            WHERE id = @TaskId
            """;

        var task = await connection.QueryFirstOrDefaultAsync<TaskResponse>(
            sql,
            new
            {
                request.TaskId
            });

        return task;
    }
}
