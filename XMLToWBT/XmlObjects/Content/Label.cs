using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class Label:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;
        protected string forId;

        public Label() : base()
        {
            forId = string.Empty;          
        }

        public override void setId(string _id)
        {
            if (_id.ToLower().Contains("lbl") || _id.ToLower().Contains("label"))
            {
                //AspxOpening.Add("<div class=\"form-group\">\n");
               // AspxClosing.Add("</div>\n");
                ID = _id;
                AspxContent.Add("  <asp:Label ID=\"" + ID+"\"");
            }
            else
            {
                ID = "lbl" + _id;
                forId = _id;
                AspxContent.Add("  <asp:Label ID=\"" + ID + "\" for=\"" + forId + "\" ");
            }
            
        }

        public override void prepareLabel(string _text)
        {
            AspxContent.Add("Text=\"" + _text + "\" />\n");
        }
    }
}
