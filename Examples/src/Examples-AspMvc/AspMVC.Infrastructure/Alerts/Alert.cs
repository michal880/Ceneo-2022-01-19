using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvc.Infrastructure.Alerts
{
  public class Alert
  {
    public string AlertClass { get; private set; }
    public string Message { get; private set; }

    public Alert(string alertClass, string message)
    {
      Message = message;
      AlertClass = alertClass;
    }
  }
}
