using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class CheckBox : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;
        public CheckBox()
            : base()
        {
           // AspxOpening.Add("<div class=\"form-group\">\n");

           // AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <asp:CheckBox ID=\""+ID+"\" runat=\"server\" CssClass=\"md-check\"/>\n");

        }
    }
}
