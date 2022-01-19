using System.Collections.Generic;
using AspMvc.Examples.Common.Client.Query;

namespace OperationConfirmation.Controllers
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}