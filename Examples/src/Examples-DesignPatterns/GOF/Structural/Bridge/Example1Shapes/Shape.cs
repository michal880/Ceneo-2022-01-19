namespace BridgeDesignPattern
{
  public abstract class Shape
  {
    protected IDrawingApi DrawingApi { get; private set; }

    public Shape(IDrawingApi drawingApi)
    {
      DrawingApi = drawingApi;
    }

    public abstract void Draw();
  }
}