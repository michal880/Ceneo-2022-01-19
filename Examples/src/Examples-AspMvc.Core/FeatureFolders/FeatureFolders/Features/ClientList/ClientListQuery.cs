using System.Collections.Generic;
using FeatureFolders.Implementation.Client.Query;

namespace CRM.Areas.ClientList.Models
{
  public class ClientListQuery
  {
    public IEnumerable<ClientSummary> Clients { get; set; } 
  }
}