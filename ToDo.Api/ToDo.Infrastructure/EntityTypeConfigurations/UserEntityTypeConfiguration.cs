using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.Username)
            .IsRequired()
            .HasMaxLength(User.MaxUsernameLength);
        builder
            .HasIndex(user => user.Username)
            .IsUnique();

        builder
            .Property(user => user.Password)
            .IsRequired()
            .HasMaxLength(User.MaxPasswordLength);
    }
}
