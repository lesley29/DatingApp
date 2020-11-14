using Domain;
using Domain.Aggregates.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder
                .Property(u => u.Gender)
                .HasConversion(new EnumToStringConverter<Gender>());

            builder.OwnsOne(u => u.Password);
            builder.OwnsMany(u => u.Photos).ToTable("photo");
        }
    }
}
