using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignPattern
{
  public class NotepadApp // Notepad
  {
    private readonly EditorCtrl _editorCtrl;
    private int _undoIndex;
    private List<Memento> _momentos = new List<Memento>();

    public NotepadApp(EditorCtrl editorCtrl)
    {
      _editorCtrl = editorCtrl;
    }

    public void Redo()
    {
      if (_undoIndex == _momentos.Count - 1)
      {
        return;
      }

      _undoIndex++;
      _editorCtrl.Restore(_momentos[_undoIndex]);

      _editorCtrl.Print();
    }

    public void Undo()
    {
      if (_undoIndex == 0)
      {
        return;
      }

      _undoIndex--;
      _editorCtrl.Restore(_momentos[_undoIndex]);

      _editorCtrl.Print();
    }

    public void Save()
    {
      _momentos.Add(_editorCtrl.GetState());
      _undoIndex = _momentos.Count;

      _editorCtrl.Print();
    }
  }
}