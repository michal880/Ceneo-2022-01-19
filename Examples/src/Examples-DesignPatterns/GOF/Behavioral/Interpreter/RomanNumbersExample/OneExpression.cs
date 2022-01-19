namespace InterpreterDesignPattern.RomanNumbersExample
{
  public class OneExpression : AbstractExpression
  {
    public override string One { get { return "I"; } }
    public override string Four { get { return "IV"; } }
    public override string Five { get { return "V"; } }
    public override string Nine { get { return "IX"; } }
    public override int Multiplier { get { return 1; } }
  }
}