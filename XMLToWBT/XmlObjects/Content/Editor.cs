using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Content
{
    public class Editor : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Editor()
            : base()
        {
            //AspxOpening.Add("<div class=\"form-group\" runat=\"server\">\n");

            //AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;
            AspxContent.Add("  <telerik:RadEditor ID=\""+ID+"\" runat=\"server\" AutoResizeHeight=\"false\" EditModes=\"Design, Html\" EnableResize=\"false\" ToolsFile=\"~/controls/telerik/RadEditorToolbar.xml\"" +
                            "CssClass=\"EditorDefault EditorPadding5\" ");
        }

        public override void prepareEditor(string _height, string _width)
        {
            AspxContent.Add("Height=\""+_height+"\" Width=\""+_width+"\"/>\n");
        }
    }
}
