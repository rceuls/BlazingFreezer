using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;

namespace BlazingFreezer.API.Models
{
    public class FreezerDataContext : DbContext
    {

        public DbSet<Freezer> Freezers { get; set; }

        public FreezerDataContext(DbContextOptions<FreezerDataContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freezer>().HasData(new Freezer
            {
                FreezerId = 1,
                Name = "Keuken"
            });
            modelBuilder.Entity<FreezerDrawer>().HasData(new FreezerDrawer
            {
                FreezerId = 1,
                FreezerDrawerId = 1,
                Name = "Bovenaan"
            });
            modelBuilder.Entity<FreezerDrawer>().HasData(new FreezerDrawer
            {
                FreezerId = 1,
                FreezerDrawerId = 2,
                Name = "Onderaan"
            });

            modelBuilder.Entity<Freezer>().HasData(new Freezer
            {
                FreezerId = 2,
                Name = "Garage"
            });
            for (var i = 0; i < 7; i++)
            {
                modelBuilder.Entity<FreezerDrawer>().HasData(new FreezerDrawer
                {
                    FreezerId = 2,
                    FreezerDrawerId = i + 3,
                    Name = $"Schuif {(i + 1)}"
                });
            }

            modelBuilder.Entity<FreezerItem>().HasData(new FreezerItem
            {
                Name = "potato",
                FreezerDrawerId = 1,
                IsVacuum = true,
                Since = DateTime.Now.AddDays(-10),
                FreezerItemId = 1
            });
            
            modelBuilder.Entity<FreezerItem>().HasData(new FreezerItem
            {
                Name = "sausage",
                FreezerDrawerId = 1,
                IsVacuum = true,
                Since = DateTime.Now.AddDays(-10),
                FreezerItemId = 2
            });

            for (var i = 0; i < 3; i++)
            {
                modelBuilder.Entity<FreezerItem>().HasData(new FreezerItem
                {
                    Name = $"spaghetti batch {i + 1}",
                    FreezerDrawerId = 3,
                    IsVacuum = false,
                    Since = DateTime.Now.AddDays(-5),
                    FreezerItemId = 3 + i
                });
            }
        }
    }
}