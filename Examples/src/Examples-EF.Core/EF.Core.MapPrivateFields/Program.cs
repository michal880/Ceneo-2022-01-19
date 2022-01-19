using System;

namespace EF.Core.MapPrivateFields
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

        using (var ctx = new OrderContext())
        {
          ctx.Database.EnsureCreated();

          Order order = new Order();
          
          ctx.Orders.Add(order);
          ctx.SaveChanges();
        }
      }
      finally
      {
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
      }
    }
  }  
}
