using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class UnreferencedTag:XmlObject

    {
        public UnreferencedTag() : base()
        {
            
        }

        public override void setId(string _id)
        {
            ID = _id;
        }
}
}
