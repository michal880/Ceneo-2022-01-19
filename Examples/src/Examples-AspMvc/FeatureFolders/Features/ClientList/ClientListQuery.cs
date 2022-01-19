using System.Collections.Generic;
using AspMvc.Examples.Common.Client.Query;

namespace CRM.Areas.ClientList.Models
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}