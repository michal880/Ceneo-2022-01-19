using System.Collections.Generic;

namespace OrderTracking.Ado
{
  public interface IAuditRepository
  {
    IEnumerable<AuditData> GetAudit(int id);
  }
}