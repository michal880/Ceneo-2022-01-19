using DDD.Specification.Base;

namespace DDD.Specification
{
  internal class AgeSpecification : CompositeSpecification<User>
  {
    private readonly int _ageFrom;
    private readonly int _ageTo;

    public AgeSpecification(int ageFrom, int ageTo)
    {
      _ageFrom = ageFrom;
      _ageTo = ageTo;
    }

    public override bool IsSatisfiedBy(User candidate)
    {
      return candidate.Age >= _ageFrom && candidate.Age <= _ageTo;
    }
  }
}