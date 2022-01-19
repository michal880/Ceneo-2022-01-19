namespace GOF.Behavioral.Command.Example1
{
  public class TurnOnCommand : ICommand
  {
    private readonly Light _light;

    public TurnOnCommand(Light light)
    {
      _light = light;
    }

    public void Execute()
    {
      // Co jezeli światło się steruje analogowo - mozna podać natężenie
      _light.TurnOn();
    }

    public void Undo()
    {
      _light.TurnOff();
    }
  }
}