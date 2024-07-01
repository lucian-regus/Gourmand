using Gourmand.Models;
using Microsoft.EntityFrameworkCore;

namespace Gourmand.Data
{
    public class GourmandDBContext : DbContext
    {
        public GourmandDBContext(DbContextOptions<GourmandDBContext> options) : base(options) { }

        public DbSet<Category> Category {get; set;}
        public DbSet<Client> Client { get; set; }
        public DbSet<Courier> Courier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Basket> Basket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Order entity
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Order)
                .HasForeignKey(o => o.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Courier)
                .WithMany(cr => cr.Order)
                .HasForeignKey(o => o.CourierID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Order)
                .HasForeignKey(o => o.RestaurantID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Basket entity
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithMany(o => o.Basket)
                .HasForeignKey(b => b.OrderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Basket)
                .HasForeignKey(b => b.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
