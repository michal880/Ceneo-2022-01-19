using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Examples.OpenClose
{
  internal class GraphicEditor
  {
    public void DrawShape(IShape s)
    {
      if (s is Circle)
      {
        DrawCircle(s as Circle);
      }
      if (s is Rectangle)
      {
        DrawRectangle(s as Rectangle);
      }
    }

    public void DrawCircle(Circle r)
    {
      //....
    }

    public void DrawRectangle(Rectangle r)
    {
      //....
    }
  }

  public interface IShape
  {
    int Type { get; }


  }

  public class Rectangle : IShape
  {
    public int Type
    {
      get { return 1; }
    }
  }

  public class Circle : IShape
  {
    public int Type
    {
      get { return 2; }
    }
  }
}