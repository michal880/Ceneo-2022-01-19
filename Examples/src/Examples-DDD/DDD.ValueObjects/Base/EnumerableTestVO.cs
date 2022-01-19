using System.Collections.Generic;
using System.Linq;

namespace DDD.ValueObjects.Base
{
  public class EnumerableTestVO : ValueObjectReflection
  {
    IEnumerable<TestVOStringWrapper> _items;
    TestVOStringWrapper[] _array;
    List<object> _list;
    
    public EnumerableTestVO(IEnumerable<TestVOStringWrapper> items)
    {
      _items = items;
      _array = items.ToArray();
      _list = items.ToList<object>();
    }
  }
}