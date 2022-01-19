using DDD.Specification.Base;

namespace DDD.Specification
{
  internal class GenderSpecification : CompositeSpecification<User>
  {
    private readonly Gender _gender;

    public GenderSpecification(Gender gender)
    {
      _gender = gender;
    }

    public override bool IsSatisfiedBy(User candidate)
    {
      return candidate.Gender == _gender;
    }
  }
}