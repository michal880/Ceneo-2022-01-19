using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace DDD.ValueObjects.Base
{
  public abstract class ValueObjectReflection : IEqualityComparer, IEquatable<ValueObjectReflection>
  {
    private const int StartValue = 397;

    public static bool operator ==(ValueObjectReflection x, ValueObjectReflection y)
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

    public static bool operator !=(ValueObjectReflection x, ValueObjectReflection y)
    {
      return !(x == y);
    }

    public virtual bool Equals(ValueObjectReflection other)
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

      IEnumerable<FieldInfo> fields = GetFields();

      foreach (FieldInfo field in fields)
      {
        object value1 = field.GetValue(other);

        object value2 = field.GetValue(this);

        if (!EqualObjects(value1, value2))
        {
          return false;
        }
      }

      return true;
    }

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
      return Equals((ValueObjectReflection)obj);
    }

    public override int GetHashCode()
    {
      IEnumerable<FieldInfo> fields = GetFields();

      int hashCode = StartValue;

      foreach (FieldInfo field in fields)
      {
        object value = field.GetValue(this);

        if (value != null)
        {
          hashCode = hashCode ^ value.GetHashCode();
        }
      }

      return hashCode;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
      Type t = GetType();

      var fields = new List<FieldInfo>();

      while (t != typeof(object))
      {
        fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

        t = t.BaseType;
      }

      return fields;
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