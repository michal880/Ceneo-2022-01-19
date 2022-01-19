using System;

namespace GOF.Behavioral.Command.Example1
{
  public class Light
  {
    public void TurnOn()
    {
      Console.WriteLine("Light is on");
    }

    public void TurnOff()
    {
      Console.WriteLine("Light is off");
    }
  }
}