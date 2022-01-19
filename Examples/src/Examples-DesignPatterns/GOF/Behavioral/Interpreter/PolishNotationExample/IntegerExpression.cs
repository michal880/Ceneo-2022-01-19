namespace InterpreterDesignPattern.PolishNotationExample
{
  internal class IntegerExpression : IExpression
  {
    private int _integer;

    public IntegerExpression(string integer)
    {
      _integer = int.Parse(integer);
    }

    public void Interpret(Context context)
    {
      context.Stack.Push(_integer);
    }
  }
}