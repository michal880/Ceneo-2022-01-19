using Xunit;
using System;

namespace DDD.ValueObjects
{
  
  public class DocumentNumberGivesMeaningToStringTest
  {
    [Fact]
    public void Equals_operator_should_work_for_equal_objects()
    {
      DocumentNumber documentNumber = "DN/1";
      DocumentNumber documentNumber2 = "DN/1";

      Assert.True(documentNumber == documentNumber2);
    }

    [Fact]
    public void Equals_operator_should_work_for_not_equal_objects()
    {
      DocumentNumber documentNumber = "DN/1";
      DocumentNumber documentNumber2 = "DN/2";

      Assert.False(documentNumber == documentNumber2);
    }

    [Fact]
    public void Equals_operator_should_work_for_equal_object_to_string()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/1";

      Assert.True(documentNumber == documentNumber2);
    }

    [Fact]
    public void Equals_operator_should_work_for_not_equal_object_to_string()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/2";

      Assert.False(documentNumber == documentNumber2);
    }

    [Fact]
    public void Equals_operator_should_work_for_inner_list()
    {
      DocumentNumber documentNumber = "DN/1";
      string documentNumber2 = "DN/2";

      Assert.False(documentNumber == documentNumber2);
    }
  }
}