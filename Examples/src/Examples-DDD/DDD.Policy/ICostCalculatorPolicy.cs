using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Policy
{
  public interface ICostCalculatorPolicy
  {
    Money Calculate(int numberOfPages);
  }
}