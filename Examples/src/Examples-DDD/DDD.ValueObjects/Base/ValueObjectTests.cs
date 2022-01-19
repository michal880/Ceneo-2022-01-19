using System.Collections.Generic;
using Xunit;

namespace DDD.ValueObjects.Base
{
  
  public class ValueObjectGivesMeaningToString
  {
    [Fact]
    public void Equals_operator_should_work_for_inner_list()
    {
      EnumerableTestVO test = new EnumerableTestVO(new TestVOStringWrapper[]{ "as1", "234" });
      EnumerableTestVO test2 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1", "234" });
      EnumerableTestVO test3 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1", "2341" });
      EnumerableTestVO test4 = new EnumerableTestVO(new TestVOStringWrapper[] { "as1" });
      
      Assert.Equal(test, test2);
      Assert.Equal(test2, test);

      Assert.NotEqual(test, test3);
      Assert.NotEqual(test3, test);

      Assert.NotEqual(test, test4);
      Assert.NotEqual(test4, test);      
    }

    [Fact]
    public void Equals_operator_should_work_for_inner_dictionary()
    {
      DictionaryTestVO test = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" }});
      DictionaryTestVO test2 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" } });
      DictionaryTestVO test3 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "2341" } });
      DictionaryTestVO test4 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as1", "234" }, { "as2", "234" } });
      DictionaryTestVO test5 = new DictionaryTestVO(
        new Dictionary<string, TestVOStringWrapper>() { { "as11", "234" } });

      Assert.Equal(test, test2);
      Assert.Equal(test2, test);

      Assert.NotEqual(test, test3);
      Assert.NotEqual(test3, test);

      Assert.NotEqual(test, test4);
      Assert.NotEqual(test4, test);

      Assert.NotEqual(test, test5);
      Assert.NotEqual(test5, test);
    }
  }
}