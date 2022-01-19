using System.Collections.Generic;

namespace GOF.Structural.Adapter.ClassAdapter
{
  internal class ClassProcessor
  {
    public void Run(IExporter exporter)
    {
      List<string> data = new List<string>();
      // do some logic

      exporter.Export(data);
    }
  }
}