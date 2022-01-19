using System;

namespace NHibernate.Mapping.ByStrings
{
  public class Date 
  {
    private DateTime _value;

    private Date(string value)
    {
      _value = DateTime.Parse(value);
    }

    private Date(DateTime value)
    {
      _value = value.Date;
    }

    public static implicit operator Date(string value)
    {
      return new Date(value);
    }

    public static implicit operator Date(DateTime value)
    {
      return new Date(value);
    }

    public static implicit operator string(Date value)
    {
      return value._value.ToString();
    }

    public static implicit operator DateTime(Date value)
    {
      return value._value;
    }

    public static Date Today
    {
      get { return new Date(DateTime.Today); }
    }
  }
}