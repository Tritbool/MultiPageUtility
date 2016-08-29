using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class RadioButton:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public RadioButton() : base()
        {
            //AspxOpening.Add("<div class=\"form-group\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;

            AspxContent.Add("  <asp:RadioButton ID=\""+ID+"\" runat=\"server\"");
        }

        public virtual void prepareRadioButton(string _onclick)
        {
            AspxContent.Add("onclick=\"" + _onclick + "\" />\n");
        }
    }
}
