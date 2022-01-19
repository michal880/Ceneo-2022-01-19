using System.Collections.Generic;

namespace GOF.Structural.Adapter.ClassAdapter
{
  internal class ExternalPdfWriterAdapter : ExternalPdfWriter, IExporter
  {
    public void Export(List<string> data)
    {
      foreach (string s in data)
      {
        Write(s);
      }
    }
  }
}