using NUnit.Framework;

namespace GOF.Behavioral.ChainOfResponsibility.Example1
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Add_shoudul_add_two_integers()
    {
      // Arrange
      Chain calc = new AddNumber(new SubstractNumber(new MultiplyNumbers(null)));

      // Act
      int result = calc.CalculateNumbers(new Numbers(1, 2, "add"));

      // Assert
      Assert.AreEqual(3, result);
    }

    [Test]
    public void Substract_should_substract_integer()
    {
      // Arrange
      Chain calc = new AddNumber(new SubstractNumber(null));

      // Act
      int result = calc.CalculateNumbers(new Numbers(1, 2, "substract"));

      // Assert
      Assert.AreEqual(-1, result);
    }
  }
}