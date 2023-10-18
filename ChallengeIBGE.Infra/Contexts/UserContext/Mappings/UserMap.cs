using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Infra.Contexts.UserContext.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);

        builder.OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .HasColumnName("LastName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Hash)
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        builder
       .HasMany(x => x.Roles)
       .WithMany(x => x.Users)
       .UsingEntity<Dictionary<string, object>>(
           "UserRole",
           role => role
               .HasOne<Role>()
               .WithMany()
               .HasForeignKey("RoleId")
               .OnDelete(DeleteBehavior.Cascade),
           user => user
               .HasOne<User>()
               .WithMany()
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade));

    }
}