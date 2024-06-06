using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(u => u.MiddleName)
            .HasMaxLength(40);

        builder.Property(u => u.LastName).HasMaxLength(20)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();

        builder.Property(u => u.BirthDate)
          .IsRequired();

        builder.Property(u => u.MobileNumber)
            .IsRequired(false);

        builder.Property(u => u.BuildingNumber)
            .IsRequired(false);

        builder.Property(u => u.FlatNumber)
            .IsRequired(false);

        builder.Property(u => u.Street)
            .IsRequired(false);

        builder
            .HasOne(e => e.Governorate)
            .WithMany(e => e.Users)
            .HasForeignKey(e => e.GovernorateId)
            .IsRequired(false);

        builder
           .HasOne(e => e.City)
           .WithMany(e => e.Users)
           .HasForeignKey(e => e.CityId)
           .IsRequired(false);
    }
}