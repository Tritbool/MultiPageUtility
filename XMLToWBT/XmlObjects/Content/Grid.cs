﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects.Content
{
    class Grid : XmlObject
    {
        protected new static readonly Node<XmlObject> generatedAspxDestinationNode = null;

        public Grid()
            : base()
        {
          //  AspxOpening.Add("<div class=\"form-group\">\n");

           // AspxClosing.Add("</div>\n");
        }

        public override void setId(string _id)
        {
            ID = _id;

            AspxContent.Add("  <telerik:RadGrid ID=\""+ID+"\" runat=\"server\" Width=\"100%\" AllowPaging=\"true\" ShowHeader=\"true\" ShowFooter=\"false\"" +
                            "ShowGroupPanel=\"false\" ShowStatusBar=\"false\" AutoGeneratedColumns=\"false\" OnNeedDataSource=\"\"" +
                            "AllowMultiRowSelection=\"true\" AllowAutomaticInserts=\"false\" AllowAutomaticDeletes=\"false\"" +
                            "AllowAutomaticUpdates=\"false\" AllowSorting=\"true\" AllowFilteringByColumn=\"true\"" +
                            "BorderStyle=\"None\" Style=\"overflow: auto;\" HeaderStyle-Font-Bold=\"true\" FilterType=\"HeaderContext\">\n");
            AspxContent.Add("    <MasterTableView CliendDataKeyNames=\"\">\n");
            AspxContent.Add("      <columns>\n");
            AspxContent.Add("      </columns>\n");
            AspxContent.Add("    </MasterTableView>\n");
            AspxContent.Add("    <ClientSettings>\n");
            AspxContent.Add("    </ClientSettings>\n");
            AspxContent.Add("  </telerik:RadGrid>\n");


        }
    }
}
