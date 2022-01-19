using System.Collections.Generic;
using AspMvc.Examples.Common.Client.Query;

namespace CommandPattern.Controllers
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}