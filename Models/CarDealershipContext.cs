using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarAppBackend.Models
{
    public partial class CarDealershipContext : DbContext
    {
        public CarDealershipContext()
        {
        }

        public CarDealershipContext(DbContextOptions<CarDealershipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarId)
                    .HasMaxLength(24)
                    .HasColumnName("carID");

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .HasColumnName("color");

                entity.Property(e => e.HasHeatedSeats).HasColumnName("hasHeatedSeats");

                entity.Property(e => e.HasLowMiles).HasColumnName("hasLowMiles");

                entity.Property(e => e.HasNavigation).HasColumnName("hasNavigation");

                entity.Property(e => e.HasPowerWindows).HasColumnName("hasPowerWindows");

                entity.Property(e => e.HasSunroof).HasColumnName("hasSunroof");

                entity.Property(e => e.IsFourWheelDrive).HasColumnName("isFourWheelDrive");

                entity.Property(e => e.Make)
                    .HasMaxLength(30)
                    .HasColumnName("make");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
