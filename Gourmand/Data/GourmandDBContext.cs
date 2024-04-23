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

    }
}
