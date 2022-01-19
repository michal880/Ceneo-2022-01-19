using System;

namespace MementoDesignPattern
{
  public class EditorCtrl // Notepad Window
  {
    private string _text; // state to track

    public Memento GetState()
    {
      return new Memento(_text);
    }

    public void Restore(Memento memento)
    {
      _text = memento.State;
    }

    public void Append(string newState)
    {
      _text += newState;
    }

    public void Print()
    {
      Console.WriteLine(_text);
    }
  }
}