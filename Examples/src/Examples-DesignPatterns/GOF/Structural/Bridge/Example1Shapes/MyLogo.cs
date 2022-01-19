namespace BridgeDesignPattern
{
  public class MyLogo : Circle
  {
    private readonly int _x;
    private readonly int _y;

    public MyLogo(int x, int y, IDrawingApi drawingApi) : base(x,y,10,drawingApi)
    {
      _x = x;
      _y = y;
    }

    public override void Draw()
    {
      base.Draw();
      new Squre(_x,_y,10,10,DrawingApi).Draw();
    }
  }
}