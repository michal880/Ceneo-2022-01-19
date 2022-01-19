using System.IO;
using System.Security.Cryptography;
using NUnit.Framework;

namespace GOF.Structural.Decorator.Example2
{
  [TestFixture]
  public class _Test
  {
    [Test]
    public void Test()
    {
      Stream s = new FileStream("c:\\test.txt", FileMode.Open);
      Stream stream = new CryptoStream(s, new ToBase64Transform(), CryptoStreamMode.Read);
      //BufferedStream s = new BufferedStream(s);
      using (StreamReader sr = new StreamReader(stream))
      {
        string result = sr.ReadToEnd();
      }
    }
  }
}
