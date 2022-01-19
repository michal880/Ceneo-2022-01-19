using NUnit.Framework;

namespace MementoDesignPattern
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test1()
    {
      EditorCtrl editorCtrl = new EditorCtrl();
      NotepadApp notepadApp = new NotepadApp(editorCtrl);

      editorCtrl.Append("ala");
      editorCtrl.Append(" ma");
      editorCtrl.Append(" kota");

      notepadApp.Save();

      editorCtrl.Append(", psa");
      editorCtrl.Append(" i cztery asy");

      notepadApp.Save();

      editorCtrl.Append(" blee");

      editorCtrl.Print();

      notepadApp.Undo();

      notepadApp.Undo();

      notepadApp.Redo();
    }
  }
}