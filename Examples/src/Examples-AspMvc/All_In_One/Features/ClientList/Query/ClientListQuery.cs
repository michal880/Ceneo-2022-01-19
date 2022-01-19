using System.Collections.Generic;
using AspMvc.Examples.Common.Client.Query;

namespace All_In_One.Features.ClientList.Query
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}