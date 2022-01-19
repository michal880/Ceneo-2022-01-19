using NUnit.Framework;

namespace BridgeDesignPattern
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      IDrawingApi asciiDriver = new AsciiDriver();
      IDrawingApi hdPixelDriver = new HdPixelDriver();
      IDrawingApi new3DDriver = new New3DDriver();

      Shape square = new Squre(10, 10, 100, 100, asciiDriver);
      Shape circle = new Circle(10, 10, 360, hdPixelDriver);
      Shape myLogo = new MyLogo(10, 10, new3DDriver);

      square.Draw();
      circle.Draw();
      myLogo.Draw();
    }
  }
}