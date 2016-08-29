using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Containers
{
    public class Actions : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Actions()
            : base()
        {
           // AspxOpening.Add("<div class = \"form-group\">\n");
            AspxOpening.Add("  <div class = \"actions\">\n");


            AspxClosing.Add("  </div>\n");
            //AspxClosing.Add("</div>\n");

        }

        public override void setId(string _id)
        {
            ID = _id;
        }
    }
}
