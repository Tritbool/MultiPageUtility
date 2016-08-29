using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Containers
{
   public class Block:XmlObject
    {
       protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

       public Block() : base()
       {
           AspxOpening.Add("<div class = \"form-group\" runat=\"server\">\n");

           AspxClosing.Add("</div>\n");
       }

       public override void setId(string _id)
       {
           ID = _id;
       }
    }
}
