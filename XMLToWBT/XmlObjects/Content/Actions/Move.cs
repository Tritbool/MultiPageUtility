using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLToWBT.XmlObjects.Actions
{
    public class Move:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Move() : base()
        {
            AspxOpening.Add("<a class=\"btn btn-circle btn-icon-only btn-default toolitps\" href=\"\" data-container=\"body\" onclick=\"\" runat=\"server\" ");
            AspxContent.Add("  <i class=\"glyphicon glyphicon-share-alt\"/>\n");
            AspxClosing.Add("</a>\n");
        }
        public override void setId(string _id)
        {
            ID = _id;
            AspxOpening.Add("ID=\""+ID+"\">\n");
            
        }
    }
}
