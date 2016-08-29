using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class DatePicker : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public DatePicker() : base()
        {
          //  AspxOpening.Add("<div class=\"form-body\">");

            AspxClosing.Add("    <DateInput ReadOnly=\"true\" ReadOnlyStyle-ForeColor=\"Black\" onclick=\"\" />\n");
            AspxClosing.Add("  </telerik:RadDatePicker>\n");
            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <telerik:RadDatePicker ID=\"" + ID + "\" runat=\"server\" EnableShadows=\"true\" ShowPopupOnFocus=\"true\" " +
                            "ShowAnimation-Type=\"Fade\" ShowAnimation-Duration=\"100\" HideAnimation-Type=\"Fade\" HideAnimation-Duration=\"100\" " +
                            "PopupDirection=\"BottomRight\" EnableScreenBoundaryDetection=\"true\" SkipMinMaxDateValidationServer=\"true\" ");
        }

        public override void prepareDatePicker(string _minDate, string _maxDate)
        {
            AspxContent.Add("MinDate=\""+_minDate+"\" MaxDate=\""+_maxDate+"\">\n");
        }


    }
}
