namespace GOF.Behavioral.State.Example2
{
  public class Pin
  {
    private readonly int _pin;

    public Pin(int pin)
    {
      _pin = pin;
    }

    public static bool operator ==(Pin a, Pin b)
    {
      // If both are null, or both are same instance, return true.
      if (System.Object.ReferenceEquals(a, b))
      {
        return true;
      }

      // If one is null, but not both, return false.
      if (((object)a == null) || ((object)b == null))
      {
        return false;
      }

      // Return true if the fields match:
      return a._pin == b._pin;
    }

    public static bool operator !=(Pin a, Pin b)
    {
      return !(a == b);
    }

    public static bool operator ==(Pin a, int b)
    {
      // If both are null, or both are same instance, return true.
      if (System.Object.ReferenceEquals(a, b))
      {
        return true;
      }

      // If one is null, but not both, return false.
      if (((object)a == null) || ((object)b == null))
      {
        return false;
      }

      // Return true if the fields match:
      return a._pin == b;
    }

    public static bool operator !=(Pin a, int b)
    {
      return !(a == b);
    }
  }
}