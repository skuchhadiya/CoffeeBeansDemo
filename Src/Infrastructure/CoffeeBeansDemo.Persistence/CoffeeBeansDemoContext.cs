using CoffeeBeansDemo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;


namespace CoffeeBeansDemo.Persistence
{
    public class CoffeeBeansDemoContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<CoffeeBean> CoffeeBeans { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity properties, relationships, etc.
            modelBuilder.Entity<CoffeeBean>()
               .HasKey(i => i.Id);

            modelBuilder.Entity<CoffeeBean>()
                .Property(i => i.Index)
                .IsRequired();


            modelBuilder.Entity<CoffeeBean>()
                .Property(i => i.IsBOTD)
                .IsRequired();

            modelBuilder.Entity<CoffeeBean>()
               .Property(i => i.Cost)
               .IsRequired()
               .HasMaxLength(6);

            modelBuilder.Entity<CoffeeBean>()
               .Property(i => i.Image)
               .IsRequired()
               .HasMaxLength(150);

            modelBuilder.Entity<CoffeeBean>()
               .Property(i => i.Colour)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<CoffeeBean>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<CoffeeBean>()
                .Property(i => i.Description)
                .IsRequired();

            modelBuilder.Entity<CoffeeBean>()
                .Property(i => i.Country)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
