using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class Hyperlink:XmlObject
    {

        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Hyperlink() : base()
        {
            //AspxOpening.Add("<div class=\"form-group\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <asp:HyperLink ID=\""+ID+"\" ");
        }

        public override void prepareHyperlink(string _text, string _url, string _onclick)
        {
            AspxContent.Add("Text=\"" + _text + "\" NavigateUrl=\"" + _url + "\" onclick=\"" + "\"/>\n");
        }
    }
}
