using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Apartments;

public static class ProjectErrors
{
    public static Error NotFound = new(
        "Project.NotFound",
        "The Project with the specified identifier was not found");

    public static readonly Error MaxMemberLimitReached = new(
        "Project.MaxMemberLimitReached",
        "The Project has reached the maximum number of allowed members.");
}