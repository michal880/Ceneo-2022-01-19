using System;

namespace VisitorPattern
{
  public class TaxVisitor : IVisitor
  {
    public double Visit(Appels appels)
    {
      return Math.Round(appels.Price*1.08,2);
    }

    public double Visit(Milk milk)
    {
      return Math.Round(milk.Price * 1.08,2);
    }

    public double Visit(Vodka vodka)
    {
      return Math.Round(vodka.Price * 1.22,2);
    }
  }
}