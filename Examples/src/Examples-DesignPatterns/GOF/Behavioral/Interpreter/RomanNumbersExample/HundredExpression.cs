namespace InterpreterDesignPattern.RomanNumbersExample
{
  public class HundredExpression : AbstractExpression
  {
    public override string One { get { return "C"; } }
    public override string Four { get { return "CD"; } }
    public override string Five { get { return "D"; } }
    public override string Nine { get { return "CM"; } }
    public override int Multiplier { get { return 100; } }
  }
}