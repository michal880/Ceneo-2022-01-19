using System;

namespace CQRS.Finders
{
  public class InventoryItemDetail 
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CurrentCount { get; set; }

    public InventoryItemDetail(Guid id, string name, int currentCount)
    {
      Id = id;
      Name = name;
      CurrentCount = currentCount;    
    }    
  }
}