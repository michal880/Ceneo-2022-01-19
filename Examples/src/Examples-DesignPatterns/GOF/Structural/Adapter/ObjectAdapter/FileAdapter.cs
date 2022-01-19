using System;
using System.IO;

namespace GOF.Structural.Adapter.ObjectAdapter
{
  public class FileAdapter : ILogWriter
  {
    private readonly string _fileName;

    public FileAdapter(string fileName)
    {
      _fileName = fileName;
    }

    public void Write(string logEntry, Level level)
    {
      File.AppendAllText(_fileName, string.Format("{0}: {1}{2}", level, logEntry, Environment.NewLine));
    }
  }
}