using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.Factories;

namespace XMLToWBT.XmlObjects.Containers
{
    public class PageView:XmlObject
    {
        public PageView() : base()
        {
            AspxOpening.Add("<telerik:RadPageView runat=\"server\" ");

            AspxClosing.Add("</telerik:RadPageView>\n");

            XmlObjectFactory fact = new XmlObjectFactory();
            generatedAspx = fact.Create("tab");
        }

        public override void setId(string _id)
        {
            ID = _id;
            string pv;
            if (ID.EndsWith("_"))
            {
                pv = "pv";
                AspxOpening.Add("ID=\"" + ID + pv + "\" ");
            }
            else
            {
                pv = "_pv";
                AspxOpening.Add("ID=\"" + ID + pv + "\" ");
            }
            generatedAspx.setId(ID);
        }

        public override void preparePageView(string _index)
        {
            AspxOpening.Add("TabIndex=\""+_index+"\">\n");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">arg 1 : css, arg 2 : index</param>
        public override void prepareGeneratedAspx(params string[] args)
        {
            if (args.Length==2)
            {
                generatedAspx.prepareTab(args[0],args[1]);
            }
        }
    }
}
