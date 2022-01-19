namespace InterpreterDesignPattern.RomanNumbersExample
{
  public class Context
  {
    public int Result { get; set; }
    public string Input { get; set; }

    public Context(string input)
    {
      Input = input;
    }
  }
}