namespace InterpreterDesignPattern.PolishNotationExample
{
  public class MinusExpression : IExpression
  {
    public void Interpret(Context context)
    {
      context.Stack.Push(context.Stack.Pop() - context.Stack.Pop());
    }
  }
}