using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace WBTMigration.Writing
{
    public class Writer
    {
        public void XmlToFile(XmlDocument doc, string path)
        {
            if(doc != null)
            doc.Save(File.Create(path));
        }


    }
}