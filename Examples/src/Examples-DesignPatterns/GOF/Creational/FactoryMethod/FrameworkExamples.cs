using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF.Creational.FactoryMethod
{
  internal class FrameworkExamples
  {
    public void FactoryMethods()
    {
      int.Parse("'34");

      DateTime.FromFileTime(23325432);

      TimeSpan.FromMilliseconds(1231243);
    }
  }
}