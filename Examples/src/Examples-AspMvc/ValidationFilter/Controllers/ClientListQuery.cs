using System.Collections.Generic;
using AspMvc.Examples.Common.Client.Query;

namespace ValidationFilter.Controllers
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}