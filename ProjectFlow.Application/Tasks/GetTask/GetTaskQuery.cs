using ProjectFlow.Application.Abstractions.Messaging;

namespace ProjectFlow.Application.Tasks.GetTask;

public sealed record GetTaskQuery(Guid TaskId) : IQuery<TaskResponse>;
