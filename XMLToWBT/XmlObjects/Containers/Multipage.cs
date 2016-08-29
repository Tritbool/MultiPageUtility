using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Containers
{
    public class Multipage : XmlObject
    {
        protected string css { get; set; }
        protected bool isFirstMultipage { get; set; }

        public Multipage()
            : base()
        {
            AspxOpening.Add("<telerik:RadMultiPage runat=\"server\" SelectedIndex =\"0\" ");
            AspxClosing.Add("</telerik:RadMultiPage>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxOpening.Add("ID=\""+ID+"\" >\n");
            XmlObjectFactory fact = new XmlObjectFactory();
            generatedAspx = fact.Create("tabstrip");
            generatedAspx.setId(ID);
        }

        public override void prepareGeneratedAspx(params string[] args)
        {
            if(args.Length == 1)
            generatedAspx.prepareTabStrip(args[0]);
        }
    }
}
