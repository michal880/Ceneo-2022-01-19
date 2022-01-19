namespace BridgeDesignPattern
{
  public class Squre : Shape
  {
    private readonly int _x;
    private readonly int _y;
    private readonly int _width;
    private readonly int _height;

    public Squre(int x, int y, int width, int height, IDrawingApi drawingApi)
      : base(drawingApi)
    {
      _x = x;
      _y = y;
      _width = width;
      _height = height;
    }

    public override void Draw()
    {
      DrawingApi.DrawLine(_x, _y, _x, _y + _height);
      DrawingApi.DrawLine(_x, _y + _height, _x + _width, _y + _height);
      DrawingApi.DrawLine(_x + _width, _y + _height, _x + _width, _y);
      DrawingApi.DrawLine(_x + _width, _y, _x, _y);
    }
  }
}