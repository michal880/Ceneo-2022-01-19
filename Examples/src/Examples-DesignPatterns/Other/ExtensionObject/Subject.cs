namespace ExtensionObjectPattern
{
  public class Subject
  {
    public virtual T GetExtension<T>() where T : class
    {
      return null;
    }
  }
}