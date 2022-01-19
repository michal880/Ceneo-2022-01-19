using System;

namespace BridgeDesignPattern
{
  public class HdPixelDriver : IDrawingApi
  {
    public void DrawLine(int x, int y, int x2, int y2)
    {
      Console.WriteLine("HDPixelDriver: Line drawn from x: {0}, y: {1} to x: {2}, y: {3}", x, y, x2, y2);
    }

    public void DrawArc(int x, int y, int angle)
    {
      Console.WriteLine("HDPixelDriver: Arc drawn at x: {0}, y: {1}, angle: {2}", x, y, angle);
    }
  }
}