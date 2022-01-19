using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace VisitorPattern
{
  // ReSharper disable InconsistentNaming
  // ReSharper disable PossibleNullReferenceException

  [TestFixture]
  public class _Test
  {
    [SetUp]
    public void SetUp()
    {      
    }

    [TearDown]
    public void TearDown()
    {

    }

    [Test]
    public void Test()
    {
      //// Arrange
      TaxVisitor taxVisitor = new TaxVisitor();

      Milk milk = new Milk(2);

      

      //// Act
      double priceWithTax = milk.Accept(taxVisitor);

      Console.WriteLine(priceWithTax);
    }   
  }

  // ReSharper restore InconsistentNaming
  // ReSharper restore PossibleNullReferenceException
}