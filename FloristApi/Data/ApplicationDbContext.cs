
using FloristApi.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<FlowerType> FlowerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed FlowerTypes (lookup table)
            modelBuilder.Entity<FlowerType>().HasData(
                new FlowerType { Id = 1, Name = "Roses" },
                new FlowerType { Id = 2, Name = "Chrysanthemums" },
                new FlowerType { Id = 3, Name = "Carnations" },
                new FlowerType { Id = 4, Name = "Natives" },
                new FlowerType { Id = 5, Name = "Gerberas" },
                new FlowerType { Id = 6, Name = "Orchids" },
                new FlowerType { Id = 7, Name = "Lilies" },
                new FlowerType { Id = 8, Name = "Tropicals" },
                new FlowerType { Id = 9, Name = "Sunflowers" },
                new FlowerType { Id = 10, Name = "Irises" },
                new FlowerType { Id = 11, Name = "Tulips" },
                new FlowerType { Id = 12, Name = "Other" }
            );
        }
    }
}
