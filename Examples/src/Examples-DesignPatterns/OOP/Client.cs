using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
  class Client1
  {
    public bool IsVip()
    {
      throw new NotImplementedException();
    }

    public decimal MoneyLeft { get; set; }
  }

  public class AppLogic1
  {
    private IRepository _repository;

    public void Charge(int clientId, decimal amount)
    {
      Client1 client = _repository.Get(clientId);

      if (client.IsVip() && client.MoneyLeft > 0)
      {
        client.MoneyLeft -= amount;
      }
    }
  }

  internal interface IRepository
  {
    Client1 Get(int clientId);
  }
}
