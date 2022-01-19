using System.Data;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace NHibernate.Base
{
  public class ValueTypeAsStringType<T> : AbstractStringType, IIdentifierType
    where T : class
  {
    public ValueTypeAsStringType()
      : base(new StringSqlType())
    {
    }

    public override string Name
    {
      get { return "String"; }
    }

    public override object FromStringValue(string xml)
    {
      return xml as T;
    }

    public override string ToString(object val)
    {
      return ((T)val).ToString();
    }
  }
}