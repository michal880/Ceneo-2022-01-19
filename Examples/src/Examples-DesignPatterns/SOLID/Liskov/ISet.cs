using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Examples.Liskov
{
  public interface ISet<T>
  {
    void Add(T item);

    void Delete(T item);

    bool IsMember(T item);
  }

  public class SpeedSet<T> : ISet<T>
  {
    public void Add(T item)
    {
      throw new NotImplementedException();
    }

    public void Delete(T item)
    {
      throw new NotImplementedException();
    }

    public bool IsMember(T item)
    {
      throw new NotImplementedException();
    }
  }

  public class LoMemSet<T> : ISet<T>
  {
    public void Add(T item)
    {
      throw new NotImplementedException();
    }

    public void Delete(T item)
    {
      throw new NotImplementedException();
    }

    public bool IsMember(T item)
    {
      throw new NotImplementedException();
    }
  }

  public class PersistentSet<T> : ISet<T> where T : PersistentObject
  {
    private ThirdPartyPersistentSet _partyPersistentSet;

    public void Add(T item)
    {
      PersistentObject pe = item as PersistentObject;
      _partyPersistentSet.Add(pe);
    }

    public void Delete(T item)
    {
      throw new NotImplementedException();
    }

    public bool IsMember(T item)
    {
      throw new NotImplementedException();
    }
  }

  internal class ThirdPartyPersistentSet
  {
    public void Add(PersistentObject pe)
    {
      throw new NotImplementedException();
    }
  }

  public class PersistentObject
  {
  }
}