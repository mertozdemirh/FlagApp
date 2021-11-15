using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlagApp.Models
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Flag> Flags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().Property(x => x.ColorName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, ColorName = "Kırmızı" },
                new Color { Id = 2, ColorName = "Beyaz" },
                new Color { Id = 3, ColorName = "Mavi" }
                );
            modelBuilder.Entity<Flag>().Property(x => x.Country).IsRequired().HasMaxLength(400);
            modelBuilder.Entity<Flag>().HasData(
                new Flag { Id = 1, Country = "Türkiye" },
                new Flag { Id = 2, Country = "Arjantin" }
                );

            modelBuilder.Entity<Color>()
                .HasMany(x => x.Flags)
                .WithMany(x => x.Colors)
                .UsingEntity<Dictionary<string, object>>(
                "FlagColor",
                x => x.HasOne<Flag>().WithMany().HasForeignKey("FlagId"),
                x => x.HasOne<Color>().WithMany().HasForeignKey("ColorId"),

                x => x.HasData(
                    new { FlagId = 1, ColorId = 1 },
                    new { FlagId = 1, ColorId = 2 },
                    new { FlagId = 2, ColorId = 2 },
                    new { FlagId = 2, ColorId = 3 }
                    ));
        }
    }
}
