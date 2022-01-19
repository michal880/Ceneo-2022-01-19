using System.Collections.Generic;

namespace DDD.ValueObjects.Base
{
  public class DictionaryTestVO : ValueObjectReflection
  {
    Dictionary<string, TestVOStringWrapper> _items;
    
    public DictionaryTestVO(Dictionary<string, TestVOStringWrapper> items)
    {
      _items = items;      
    }
  }
}