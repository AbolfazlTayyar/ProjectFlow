namespace ProjectFlow.Domain.Projects;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Project project);
}
