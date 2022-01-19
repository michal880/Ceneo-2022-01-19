using NUnit.Framework;

namespace InterpreterDesignPattern.PolishNotationExample
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      string equation = "- + 5 6 1";
      int expectedResult = 10;

      Parser parser = new Parser();

      parser.Parse(equation);
      
      Assert.AreEqual(expectedResult,  parser.Evaluate());
    }
  }
}