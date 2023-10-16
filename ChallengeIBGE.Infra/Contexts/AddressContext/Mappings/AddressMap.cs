using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.State)
            .HasColumnName("State")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2);
        builder.Property(x => x.City)
            .HasColumnName("City")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.HasIndex(x => x.State).HasDatabaseName("IX_Address_State");
        builder.HasIndex(x => x.City).HasDatabaseName("IX_Address_City");
    }
}
