using System;
using System.Runtime.Remoting.Messaging;

namespace OrderTracking
{
  public class OrderContext
  {
    private const string ContextOperationId = "OrderTrackingId";

    public static Guid New()
    {
      return Id = Guid.NewGuid();
    }

    public static Guid Id
    {
      get
      {
        return (Guid)CallContext.LogicalGetData(ContextOperationId);
      }
      set
      {
        CallContext.LogicalSetData(ContextOperationId, value);
      }
    }


  }
}