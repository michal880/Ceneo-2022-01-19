using System;
using System.Collections;

namespace DDD.Policy
{
  public abstract class ValueObject : IEqualityComparer, IEquatable<ValueObject>
  {
    private const int StartValue = 397;

    public static bool operator ==(ValueObject x, ValueObject y)
    {
      if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
      {
        return true;
      }

      if (ReferenceEquals(x, null))
      {
        return false;
      }

      return x.Equals(y);
    }

    public static bool operator !=(ValueObject x, ValueObject y)
    {
      return !(x == y);
    }

    public virtual bool Equals(ValueObject other)
    {
      if (other == null)
      {
        return false;
      }

      Type t = GetType();

      Type otherType = other.GetType();

      if (t != otherType)
      {
        return false;
      }

      var values = GetValues();
      var otherValues = other.GetValues();

      for(int i =0;i<values.Length;i++)
      {
        object value1 = values[i];

        object value2 = otherValues[i];

        if (!EqualObjects(value1, value2))
        {
          return false;
        }
      }

      return true;
    }

    protected abstract object[] GetValues();

    private bool EqualObjects(object value1, object value2)
    {
      if (value1 == null)
      {
        if (value2 != null)
        {
          return false;
        }
      }

      if (value1 is IEnumerable && !(value1 is string))
      {
        if (!(value2 is IEnumerable))
        {
          return false;
        }

        var enumerator1 = (value1 as IEnumerable).GetEnumerator();
        var enumerator2 = (value2 as IEnumerable).GetEnumerator();
        bool nextv1 = false, nextv2 = false;

        while (true)
        {
          nextv1 = enumerator1.MoveNext();
          nextv2 = enumerator2.MoveNext();
          if (nextv1 && nextv2)
          {
            if (!EqualObjects(enumerator1.Current, enumerator2.Current))
            {
              return false;
            }
          }
          if (!nextv1 && !nextv2)
          {
            return true;
          }
          if (nextv1 != nextv2)
          {
            return false;
          }
        }
      }
      else
      {
        return value1.Equals(value2);
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ValueObject)obj);
    }

    public override int GetHashCode()
    {
      var values = GetValues();

      int hashCode = StartValue;

      foreach (var value in values)
      {
        if (value != null)
        {
          hashCode = hashCode ^ value.GetHashCode();
        }
      }

      return hashCode;
    }

    public new bool Equals(object x, object y)
    {
      if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
      {
        return true;
      }

      if (ReferenceEquals(x, null))
      {
        return false;
      }

      return x.Equals(y);
    }

    public int GetHashCode(object obj)
    {
      return obj.GetHashCode();
    }
  }
}