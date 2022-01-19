using System;
using System.IO;
using GOF.Structural.Adapter.ClassAdapter;
using GOF.Structural.Adapter.ObjectAdapter;
using NUnit.Framework;

namespace GOF.Structural.Adapter
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void ClassAdapterExample()
    {
      ExternalPdfWriterAdapter externalPdfWriter = new ExternalPdfWriterAdapter();

      ClassProcessor p = new ClassProcessor();
      p.Run(externalPdfWriter);
    }

    [Test]
    public void ObjectAdapterExample()
    {
      string fileName = "adapterTest.log";
      ObjectProcessor processor = new ObjectProcessor();

      File.Delete(fileName);

      ILogWriter logWriter = new FileAdapter(fileName);

      processor.Run(logWriter);

      Console.WriteLine(File.ReadAllText(fileName));
    }
  }
}