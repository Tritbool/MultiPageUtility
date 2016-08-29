using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class NumericTextBox:XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public NumericTextBox() : base()
        {
            //AspxOpening.Add("<div class=\"form-group\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;

            AspxContent.Add("  <telerik:RadNumericTextBox ID=\""+ID+"\" runat=\"server\" CssClass=\"form-control input-sm\" placeholder=\"\" ShowSpinButtons=\"false\"");
        }

        public override void prepareNumericTextBox(string _minValue, string _maxValue)
        {
            AspxContent.Add("MinValue=\"" + _minValue + "\" MaxValue=\"" + _maxValue + "\" Width=\"100%\" AllowOutOfRangeAutoCorrect=\"true\" Type=\"Number\">\n");
            AspxContent.Add("    <IncrementSettings InterceptArrowKeys=\"false\" InterceptMouseWheel=\"false\"/>\n");
            AspxContent.Add("    <NumberFormat DecimalDigits=\"0\" GroupSeparator=\"\" />\n");
            AspxContent.Add("  </telerik:RadNumericTextBox>\n");
        }

    }
}
