using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
  public class Data
  {
    public void ProcessStep2()
    {
      throw new NotImplementedException();
    }

    public IParam Param1 { get; set; }
  }

  public interface IParam
  {
    void DoStap2();
  }


  class ApplicationLogic
  {
    public void Process(Data data)
    {
      
    }
  }
}
