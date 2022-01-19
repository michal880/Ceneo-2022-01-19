using System;
using NUnit.Framework;

namespace GOF.Behavioral.Visitor.HtmlExample
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      Node root = new Html();

      root.Add(new Head());

      Body body = new Body();
      root.Add(body);

      Div div = new Div();
      body.Add(div);

      div.Add(new A("http://www.google.pl"));

      HtmlVisitor htmlVisitor = new HtmlVisitor();
      root.Accept(htmlVisitor);

      Console.WriteLine(htmlVisitor.PrintHtml());
    }
  }
}
