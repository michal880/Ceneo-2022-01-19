using Microsoft.EntityFrameworkCore;

namespace EF.Core.MapPrivateFields
{
  public class OrderContext : DbContext
  {
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=Database;trusted_connection=true");      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>().Property<int>("Id").HasField("_id");
      modelBuilder.Entity<Order>().Property<string>("Data").HasField("_data");
    }  
  }
}