using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    public class Caption:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Caption() : base()
        {
           // AspxOpening.Add("<div class=\"form-group\">\n");
            AspxOpening.Add("  <telerik:RadCodeBlock runat=\"server\">\n");
            AspxOpening.Add("    <div class=\"caption\">\n");
            AspxOpening.Add("      <span class=\"caption-subject font-green bold uppercase\">\n");

            AspxClosing.Add("      </span>\n");
            AspxClosing.Add("    </div>\n");
            AspxClosing.Add("  </telerik:RadCodeBlock>\n");
            //AspxClosing.Add("</div>\n");


        }

        public override void setId(string _id)
        {
            ID = _id;        
            AspxContent.Add("        <%= oLoc.GetString(\"Lbl"+ID+"\", oUser.Subdomain) %>\n");
        }
    }
}
