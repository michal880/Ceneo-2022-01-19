namespace Examples.Autofac.Core
{
  public class DisposableComponent : IDisposableComponent, IDisposable
  {
    public static bool Disposed = false;

    private void ReleaseUnmanagedResources()
    {
      Disposed = true;
    }

    public void Dispose()
    {
      ReleaseUnmanagedResources();
      GC.SuppressFinalize(this);
    }

    ~DisposableComponent()
    {
      ReleaseUnmanagedResources();
    }
  }
}