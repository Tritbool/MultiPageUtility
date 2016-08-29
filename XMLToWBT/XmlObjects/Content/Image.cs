using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class Image:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Image() : base()
        {
          //  AspxOpening.Add("<div class=\"form-group\">\n");

           // AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <asp:Image ID=\""+ID+"\" ");
        }

        public override void prepareImage(string _onclick)
        {
            AspxContent.Add("onClick=\"" + _onclick + "\"/>\n");
        }
    }
}
