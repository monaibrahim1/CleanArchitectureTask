using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class AddressCountConfig : IEntityTypeConfiguration<AddressCount>
{
    public void Configure(EntityTypeBuilder<AddressCount> builder)
    {
        builder
            .HasOne(e => e.Governorate)
            .WithOne(e => e.AddressCount)
            .HasForeignKey<AddressCount>();
    }
}