using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using CustomerCards.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCards.DAL
{
    public class CustomersCardsContext: DbContext
    {
        public CustomersCardsContext() { }

        public CustomersCardsContext(DbContextOptions options) : base(options) { }

        public DbSet<PersonalCard> PersonalCards { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new ConnectionStringManager().ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
            modelBuilder.ApplyConfiguration(new PurchaseConfig());
            modelBuilder.ApplyConfiguration(new PersonalCardConfig());
        }
    }
}
