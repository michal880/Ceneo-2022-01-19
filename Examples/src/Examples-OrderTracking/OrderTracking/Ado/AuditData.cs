using System;

namespace OrderTracking.Ado
{
  public class AuditData
  {
    public string Data { get; set; }
    public Guid OrderId { get; set; }
  }
}