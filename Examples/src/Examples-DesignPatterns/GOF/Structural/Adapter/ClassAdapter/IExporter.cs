using System.Collections.Generic;

namespace GOF.Structural.Adapter.ClassAdapter
{
  internal interface IExporter
  {
    void Export(List<string> data);
  }
}