using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class ComboBox:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;
        public ComboBox() : base()
        {
            //AspxOpening.Add("<div class=\"form-group\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <telerik:RadComboBox runat=\"server\" ID=\""+ID+"\" Width=\"100%\" EnableLoadOnDemand=\"false\" CausesValidation=\"False\" AllowCustomText=\"false\" EnableTextSelection=\"false\"/>\n");
            

        }
    }
}
