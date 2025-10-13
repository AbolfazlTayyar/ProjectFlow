using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
