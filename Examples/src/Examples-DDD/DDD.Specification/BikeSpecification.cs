using DDD.Specification.Base;

namespace DDD.Specification
{
  internal class BikeSpecification : CompositeSpecification<User>
  {
    private readonly MotorbikeType _motorbikeType;

    public BikeSpecification(MotorbikeType motorbikeType)
    {
      _motorbikeType = motorbikeType;
    }

    public override bool IsSatisfiedBy(User candidate)
    {
      return candidate.MotorbikeType == _motorbikeType;
    }
  }
}