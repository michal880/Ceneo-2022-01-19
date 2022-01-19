namespace InterpreterDesignPattern.RomanNumbersExample
{
  public abstract class AbstractExpression : IExpression
  {
    public void Interpret(Context context)
    {
      if (context.Input.Length == 0)
        return;

      if (context.Input.StartsWith(Nine))
      {
        context.Result += 9 * Multiplier;
        context.Input = context.Input.Substring(2);
      }
      else if (context.Input.StartsWith(Four))
      {
        context.Result += 4 * Multiplier;
        context.Input = context.Input.Substring(2);
      }
      else if (context.Input.StartsWith(Five))
      {
        context.Result += 5 * Multiplier;
        context.Input = context.Input.Substring(1);
      }

      while (context.Input.StartsWith(One))
      {
        context.Result += 1 * Multiplier;
        context.Input = context.Input.Substring(1);
      }
    }

    public abstract string One { get; }
    public abstract string Four { get; }
    public abstract string Five { get; }
    public abstract string Nine { get; }
    public abstract int Multiplier { get; }

  }
}