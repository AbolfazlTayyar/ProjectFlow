using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.ProjectMembers;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Infrastructure.Configurations;

internal sealed class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.ToTable("projectMembers");

        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId);

        builder.Property(x => x.Role)
            .HasConversion<string>();

        builder.Property(x => x.ExperienceLevel)
            .HasConversion<string>();
    }
}
