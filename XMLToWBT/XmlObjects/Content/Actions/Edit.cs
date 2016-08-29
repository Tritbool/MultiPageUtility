using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Actions
{
    public class Edit:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Edit() : base()
        {
            AspxOpening.Add("<a class=\"btn btn-circle btn-icon-only btn-default toolitps\" href=\"\" data-container=\"body\" onclick=\"\" runat=\"server\" ");
            AspxContent.Add("  <i class=\"fa fa-pencil\"/>\n");
            AspxClosing.Add("</a>\n");
        }
        public override void setId(string _id)
        {
            ID = _id;
            AspxOpening.Add("ID=\""+ID+"\">\n");
            
        }
    }
}
