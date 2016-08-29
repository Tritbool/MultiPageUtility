using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Containers
{
    public class TabStrip : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public TabStrip()
            : base()
        {
            AspxOpening.Add("<telerik:RadTabStrip runat=\"server\" OnClientTabSelecting=\"\" ");

            AspxContent.Add("  <Tabs>\n");

            AspxClosing.Add("  </Tabs>\n");
            AspxClosing.Add("</telerik:RadTabStrip>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxOpening.Add("ID=\"" + ID + "TabStrip\" " + "MultiPageID=\"" + ID + "\" ");
        }

        public override void prepareTabStrip(string _orientation)
        {
            if (_orientation != string.Empty)
            {   AspxOpening.Insert(0,"<div class=\"col-md-2 col-xs-3\">\n");
                AspxOpening.Add("Orientation=\"" + _orientation + "\" Width=\"100%\" Skin=\"\" SelectedIndex=\"0\">\n");
                AspxClosing.Add("</div>\n");
            }
            else
                AspxOpening.Add("\" Width=\"100%\" Skin=\"\" SelectedIndex=\"0\">\n");
        }
    }
}
