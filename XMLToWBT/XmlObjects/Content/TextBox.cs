using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class TextBox:XmlObject
    {

        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public TextBox() : base()
        {
            //AspxOpening.Add("<div class=\"form-group\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;

            AspxContent.Add("  <asp:TextBox ID=\""+ID+"\" runat=\"server\" CssClass=\"form-control input-sm\" placeholder=\"\"");
        }

        public override void prepareTextBox(string _textMode, string _maxLength)
        {
            AspxContent.Add("MaxLength=\"" + _maxLength + "\" TextMode=\"" + _textMode + "\"/>\n");
        }
    }
}
