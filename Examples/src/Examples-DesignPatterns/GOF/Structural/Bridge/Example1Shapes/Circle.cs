namespace BridgeDesignPattern
{
  public class Circle : Shape
  {
    private readonly int _x;
    private readonly int _y;
    private readonly int _angle;

    public Circle(int x, int y, int angle, IDrawingApi drawingApi)
      : base(drawingApi)
    {
      _x = x;
      _y = y;
      _angle = angle;
    }

    public override void Draw()
    {
      DrawingApi.DrawArc(_x, _y, _angle);
    }
  }
}