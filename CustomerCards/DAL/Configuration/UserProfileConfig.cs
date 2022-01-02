using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCards.DAL.Configuration
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("user_profile");

            builder.HasKey(uP => uP.UserId);

            builder.Property(uP => uP.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint");

            builder.Property(uP => uP.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(uP => uP.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar(50)");

            builder.Property(uP => uP.LastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar(50)");

            builder.Property(uP => uP.Birthdate)
                .HasColumnName("birthdate")
                .HasColumnType("date");

            builder.HasOne(uP => uP.PersonalCard)
                .WithOne(pC => pC.UserProfile)
                .HasForeignKey<UserProfile>(uP => uP.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
