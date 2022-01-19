using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InterpreterDesignPattern.RomanNumbersExample
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      RomanDateParser parser = new RomanDateParser();
      Assert.AreEqual("1977", parser.Parse("MCMLXXVII"));
    }
  }
}
