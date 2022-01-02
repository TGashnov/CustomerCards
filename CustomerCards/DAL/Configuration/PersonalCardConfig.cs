using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCards.DAL.Configuration
{
    class PersonalCardConfig : IEntityTypeConfiguration<PersonalCard>
    {
        public void Configure(EntityTypeBuilder<PersonalCard> builder)
        {
            builder.ToTable("personal_card");

            builder.HasKey(pC => pC.Id);

            builder.Property(pC => pC.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            builder.Property(pC => pC.Discount)
                .HasColumnName("discount")
                .HasColumnType("real");
        }
    }
}
