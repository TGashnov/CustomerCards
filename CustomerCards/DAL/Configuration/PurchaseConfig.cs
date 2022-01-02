using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCards.DAL.Configuration
{
    class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            
            builder.ToTable("purchase");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            builder.Property(p => p.CardId)
                .HasColumnName("card_id")
                .HasColumnType("bigint");

            builder.Property(p => p.PurchaseSum)
                .HasColumnName("purchase_sum")
                .HasColumnType("decimal(18,0)");

            builder.HasOne(p => p.PersonalCard)
                .WithMany(pC => pC.Purchases)
                .HasForeignKey(p => p.CardId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
