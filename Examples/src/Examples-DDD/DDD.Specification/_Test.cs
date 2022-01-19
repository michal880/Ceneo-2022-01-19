using Xunit;
using System;
using DDD.Specification.Base;

namespace DDD.Specification
{
  
  public class _Test
  {
    [Fact]
    public void RockersSpecificationExample()
    {
      ISpecification<User> grandpaRockersSpecification =
        new GenderSpecification(Gender.Male)
          .And(new AgeSpecification(60, 100))
          .And(new BikeSpecification(MotorbikeType.Suzuki).Not())
          .And(
            new BikeSpecification(MotorbikeType.HarleyDavidson)
              .Or(new BikeSpecification(MotorbikeType.Honda)));

      bool result = grandpaRockersSpecification.IsSatisfiedBy(GetCurrentUser());

      Assert.True(result);
    }

    private User GetCurrentUser()
    {
      return new User() { Age = 80, Gender = Gender.Male, MotorbikeType = MotorbikeType.HarleyDavidson };
    }
  }
}