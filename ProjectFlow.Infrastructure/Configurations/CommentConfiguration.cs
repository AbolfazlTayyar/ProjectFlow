using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Comments;
using ProjectFlow.Domain.Task;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Infrastructure.Configurations;

internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(x => x.Id);

        builder.HasOne<ProjectTask>()
            .WithMany()
            .HasForeignKey(p => p.TaskId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.AssigneeId);

        builder.Property(x => x.Note)
            .HasMaxLength(2000)
            .HasConversion(x => x.Value, value => new Note(value));
    }
}
