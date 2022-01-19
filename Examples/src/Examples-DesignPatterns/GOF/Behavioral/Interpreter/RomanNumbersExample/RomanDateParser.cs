using System.Collections.Generic;

namespace InterpreterDesignPattern.RomanNumbersExample
{
  internal class RomanDateParser
  {
    private IExpression[] _expressions = 
      {
        new ThousandExpression(),
        new HundredExpression(),
        new TenExpression(),
        new OneExpression(),
      };

    public string Parse(string romanNumber)
    {
      Context context = new Context(romanNumber);
      foreach (var expression in _expressions)
      {
        expression.Interpret(context);
      }
      return context.Result.ToString();
    }
  }
}