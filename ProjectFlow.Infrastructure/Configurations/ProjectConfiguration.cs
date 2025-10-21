using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Projects;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Infrastructure.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.CreatedByUserId);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, value => new Name(value));

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(x => x.Value, value => new Description(value));

        builder.OwnsOne(x => x.DateRange);

        builder.OwnsOne(x => x.TimeEstimate);

        builder.OwnsOne(x => x.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });
    }
}
