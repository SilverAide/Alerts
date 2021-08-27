using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using Domain.Models;

namespace DataAccess
{
    public class AlertDbContext : DbContext
    {

        public AlertDbContext([NotNull] DbContextOptions options) :
            base(options)
        { }

        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(e => e.Id);



                entity.Property(e => e.Description)
                    .IsRequired(true);

                entity.Property(e => e.Timestamp)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Alert>()
                .HasData(new[]
                {
                    new Alert
                    { 
                        Id = 1,
                        Description = "This is a test alert",
                        Timestamp = DateTime.Now
                    },
                    new Alert
                    {
                        Id = 2,
                        Description = "This is another test alert",
                        Timestamp = DateTime.Now
                    },
                    new Alert
                    {
                        Id = 3,
                        Description = "This is the last test alert",
                        Timestamp = DateTime.Now
                    },
                });

        }
    }
}
