namespace InterpreterDesignPattern.RomanNumbersExample
{
  public class TenExpression : AbstractExpression
  {
    public override string One { get { return "X"; } }
    public override string Four { get { return "XL"; } }
    public override string Five { get { return "L"; } }
    public override string Nine { get { return "XC"; } }
    public override int Multiplier { get { return 10; } }
  }
}