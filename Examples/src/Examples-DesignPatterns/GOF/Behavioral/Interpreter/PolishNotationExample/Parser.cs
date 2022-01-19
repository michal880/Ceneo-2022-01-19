using System.Collections.Generic;
using System.Linq;

namespace InterpreterDesignPattern.PolishNotationExample
{
  public class Parser
  {
    private List<IExpression> _expressions;
    
    public void Parse(string equation)
    {
      _expressions = new List<IExpression>();

      IEnumerable<string> tokens = equation.Split(' ').Reverse();
      foreach (string token in tokens)
      {
        switch (token)
        {
          case "+":
            _expressions.Add(new PlusExpression());
            break;
          case "-":
            _expressions.Add(new MinusExpression());
            break;
          default:
            _expressions.Add(new IntegerExpression(token));
            break;
        }
      }
    }   

    public int Evaluate()
    {
      Context context = new Context();
      foreach (IExpression expression in _expressions)
      {
        expression.Interpret(context);
      }
      return context.Stack.Pop();
    }
  }
}