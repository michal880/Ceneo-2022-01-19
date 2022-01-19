using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
  /************************
  
  1. tego samego obiektu 
  2. dowolnego parametru przekazanego do niej 
  3. dowolnego obiektu przez nią stworzonego 
  4. dowolnego składnika, klasy do której należy dana metoda 

  *************************/
  
  public class ClientProcessor
  {
    private IRepository _repositry;

    public void Process(Data input)
    {
      ProcessStep1();
      input.ProcessStep2();

      Data temporary = new Data();

      Client1 data = _repositry.Get(1);


      input.Param1.DoStap2(); // ERROR - violation of Law of Demeter!!!
    }

    private void ProcessStep1()
    {
      
    }
  }

}
