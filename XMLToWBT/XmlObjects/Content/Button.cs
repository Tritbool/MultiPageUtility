using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class Button:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Button() : base()
        {
           // AspxOpening.Add("<div class=\"form-group\">\n");
           
          //  AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <asp:Button runat=\"server\" CssClass=\"btn intermediateAction\"");
            AspxContent.Add("ID=\""+ID+"\" ");
            
        }

        public override void prepareButton(string _text, string _onclick)
        {
            AspxContent.Add("Text=\""+_text+"\" "+"OnClientClick=\""+_onclick+"\"/>\n");
        }
    }
}
