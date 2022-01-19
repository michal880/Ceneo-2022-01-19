using System;
using System.IO;
using System.Xml;
using NUnit.Framework;

namespace GOF.Structural.Composite.Example1
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

      using (StringWriter sw = new StringWriter())
      {
        using (XmlWriter xmlWriter = new XmlTextWriter(sw))
        {
          root.GetHtml(xmlWriter);
        }
        Console.WriteLine(sw.GetStringBuilder().ToString());
      }
    }
  }
}
