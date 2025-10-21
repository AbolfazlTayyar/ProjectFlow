using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Task;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Infrastructure.Configurations;

internal sealed class TaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.ToTable("projectTasks");

        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.AssigneeId);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, value => new Title(value));

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(x => x.Value, value => new Domain.Task.Description(value));

        builder.OwnsOne(x => x.Effort);

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.Property(x => x.Priority)
            .HasConversion<string>();

        builder.Property(x => x.Complexity)
            .HasConversion<string>();
    }
}
