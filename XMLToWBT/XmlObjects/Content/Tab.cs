using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class Tab : XmlObject
    {
        public Tab()
            : base()
        {
            AspxOpening.Add("<telerik:RadTab runat=\"server\" ");
        }

        public override void setId(string _id)
        {
            ID = _id;
            string tab, pv;
            if (ID.EndsWith("_"))
            {
                tab = "tab";
                pv = "pv";

                AspxOpening.Add("Value=\"" + ID + tab + "\" " + "PageViewID=\"" + ID + pv + "\" ");
            }
            else
            {
                tab = "_tab";
                pv = "_pv";

                AspxOpening.Add("Value=\"" + ID + tab + "\" " + "PageViewID=\"" + ID + pv + "\" ");
            }
        }

        public override void prepareTab(string _css, string _index)
        {
            AspxOpening.Add("TabIndex=\"" + _index + "\" ");
            if (_index != string.Empty)
                AspxOpening.Add("CssClass=\"" + _css + "\" " + "SelectedCssClass=\"" + _css + "Selected\" " + "HoveredCssClass=\"" + _css + "Hovered\" " + "DisabledCssClass=\"" + _css + "Disabled\" />\n");
            else
                AspxOpening.Add("/>\n");
        }
    }
}
