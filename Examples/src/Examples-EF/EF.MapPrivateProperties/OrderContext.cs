using System.Data.Entity;

namespace EF.MapPrivateProperties
{
  public class OrderContext : DbContext
  {
    public OrderContext() : base("name=WebApplication1Context")
    {
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Add<NonPublicColumnAttributeConvention>();
    }
  }
}