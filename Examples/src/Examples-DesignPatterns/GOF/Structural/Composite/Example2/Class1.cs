using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GOF.Structural.Composite.Example2
{
  internal class Class1
  {
    public void XmlDocumentExample()
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlNodeList list = xmlDocument.ChildNodes;
      XmlNode node = list.Item(0);
    }

    public void FormsExample()
    {
      Panel uc = new Panel();
      Control c = uc.Controls[0];
    }
  }
}