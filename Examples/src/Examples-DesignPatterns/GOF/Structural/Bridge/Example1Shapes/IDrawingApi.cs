using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
  public interface IDrawingApi
  {
    void DrawLine(int x, int y, int x2, int y2);
    void DrawArc(int x, int y, int angle);
  }
}
