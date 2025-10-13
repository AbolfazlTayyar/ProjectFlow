using ProjectFlow.Domain.Abstractions;

namespace ProjectFlow.Domain.Apartments;

public static class ProjectMemberErrors
{
    public static Error NotFound = new(
        "ProjectMember.NotFound",
        "The ProjectMember with the specified identifier was not found");
}