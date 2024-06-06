using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .HasOne(e => e.Governorate)
            .WithMany(e => e.Cities)
            .HasForeignKey(e => e.GovernorateId)
            .IsRequired();
    }
}