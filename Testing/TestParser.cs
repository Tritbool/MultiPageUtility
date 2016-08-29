using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBTMigration.Parsing;
using WBTMigration.Writing;
using XMLToWBT.XmlToAspx;

namespace Testing
{
    [TestClass]
    public class TestParser
    {
        private void showXML(XmlReader node, string spc)
        {
            while (node.Read())
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    Console.Write(spc + node.Name);
                    for (int i = 0; i < node.AttributeCount; i++)
                    {
                        Console.Write(" " + node.GetAttribute(i));
                    }
                    Console.WriteLine("");
                }
            }

        }


        private void showXML1(XmlNode node, string spc)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(spc + child.Name);
                    showXML1(child, "  ");
                }
            }

        }

        [TestMethod]
        public void TestXmlTo40()
        {
            Parser p = new Parser();
            //  Stream fs = File.OpenRead(@"c:\theme.xml");
            //  XmlReader xr= XmlReader.Create(fs);
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\ASPX_XML_files\webinare.xml");
            //    showXML(xr, "");
            // showXML1(doc, "  ");


            Console.WriteLine(p.parseXml(doc));

        }

        [TestMethod]
        public void TestMultipleXmlTo40()
        {
            Parser p = new Parser();
            //Stream fs = File.OpenRead(@"c:\theme.xml");
            // XmlReader xr = XmlReader.Create(fs);
            XmlDocument doc = new XmlDocument();           

            DirectoryInfo d = new DirectoryInfo(@"C:\ASPX_XML_files");
            FileInfo f = default(FileInfo);
            try
            {
                foreach (var file in d.GetFiles("*.xml"))
                {
                    doc = new XmlDocument();
                    doc.Load(@"c:\ASPX_XML_files\" + file.Name);
                    f = file;

                    StreamWriter outputFile = new StreamWriter(@"c:\ASPX_XML_files\" + file.Name.Replace(".xml", ".aspx"));
                    outputFile.AutoFlush = true;
                    outputFile.Write(p.parseXml(doc));
                    outputFile.Close();


                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
