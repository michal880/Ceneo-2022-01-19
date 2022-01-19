namespace InterpreterDesignPattern.RomanNumbersExample
{
  public class ThousandExpression : AbstractExpression
  {
    public override string One { get { return "M"; } }
    public override string Four { get { return " "; } }
    public override string Five { get { return " "; } }
    public override string Nine { get { return " "; } }
    public override int Multiplier { get { return 1000; } }
  }
}