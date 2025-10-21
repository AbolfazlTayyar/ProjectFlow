using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Domain.Users;

namespace ProjectFlow.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(x => x.LastName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11)
            .HasConversion(phoneNumber => phoneNumber.Value, value => new PhoneNumber(value));

        builder.HasIndex(x => x.PhoneNumber).IsUnique();

        builder.Property(x => x.Email)
            .HasMaxLength(400)
            .HasConversion(email => email.Value, value => new Domain.Users.Email(value));

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
