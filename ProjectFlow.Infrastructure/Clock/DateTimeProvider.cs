using ProjectFlow.Application.Abstractions.Clock;

namespace ProjectFlow.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
