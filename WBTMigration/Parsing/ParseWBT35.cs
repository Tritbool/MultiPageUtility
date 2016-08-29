using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using ASP;

namespace WBTMigration.Parsing
{
    public class ParseWBT35
    {

        private int unhandled = 0;
        /* Gets the first multipage found in the tag children */
        public ASP.Tag FindFirstMultiPage(ASP.Tag tag)
        {
            ASP.Tag val = null;
            foreach (ASP.Tag child in tag.ChildTags)
            {

                if (child.Name.ToLower().Equals("telerik:radmultipage") && child.TagType == ASP.TagType.Open)
                {
                    val = child;
                }
                else
                    val = val ?? FindFirstMultiPage(child);
            }
            return val;
        }

        /* Gets all the tags which name corresponds to tagname. These tags are inserted in the tag list tl */
        public void FindAllTags(ASP.Tag tag, List<ASP.Tag> tl, string tagname, bool directParent)
        {
            foreach (ASP.Tag child in tag.ChildTags)
            {

                if (child.Name.ToLower().Equals(tagname.ToLower()) && child.TagType == ASP.TagType.Open)
                {
                    tl.Add(child);
                }
                if (!directParent)
                {
                    FindAllTags(child, tl, tagname, false);
                }

            }
        }

        /* Gets all the controls that are present in the tag children.
           These controls are inserted in the tag list tl
         
         * IF a control is missing, just add a case in the switch.
         */
        public void FindControls(ASP.Tag tag, List<ASP.Tag> tl)
        {
            foreach (ASP.Tag child in tag.ChildTags)
            {
                if (child.TagType == ASP.TagType.Open)
                {

                    switch (child.Name.ToLower())
                    {

                        case "telerik:radmultipage":
                        case "asp:textbox":
                        case "telerik:raddatepicker":
                        case "telerik:radgrid":
                        case "asp:checkbox":
                        case "asp:hyperlink":
                        case "telerik:radcombobox":
                        case "asp:label":
                        case "telerik:radnumerictextbox":
                        case "asp:button":
                        case "asp:image":

                            tl.Add(child);

                            break;
                        default:
                            if (child.Value.ToLower().Contains("telerik") || child.Value.ToLower().Contains("asp") || child.Value.ToLower().Contains("wbt"))
                            {
                                if (!child.Value.ToLower().Contains("radtabstrip") && !child.Value.ToLower().Contains("radtab") && !child.Value.ToLower().Contains("page"))
                                    tl.Add(child);

                            }
                            break;
                    }
                    if (child.Value.ToLower().Contains("toolbar"))
                    {

                        tl.Add(child);

                    }
                    if (child.Name.ToLower() != "telerik:radgrid")
                        FindControls(child, tl);
                }
            }
        }

        /* returns the xml corresponding to the passed tag */
        public XmlNode getXml(ASP.Tag tag, XmlDocument tmpDoc)
        {

            XmlNode newElement;
            XmlAttribute xmlAttrId = tmpDoc.CreateAttribute("ID");
            xmlAttrId.Value = string.Empty;

            string id = string.Empty;


            switch (tag.Name.ToLower())
            {
                case "telerik:radmultipage":
                    return ParseMultiPage(tag, tmpDoc);
                    break;
                case "telerik:radpageview":
                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        if (attr.Key.ToLower() == "id")
                        {
                            id = attr.Value;
                        }

                    }
                    if (id != string.Empty)
                    {
                        string idValue = "";
                        if (id.Contains('_'))
                        {
                            var id_nom = id.Split('_');


                            for (int i = 0; i < id_nom.Length - 1; i++)
                            {
                                idValue += id_nom[i];
                                idValue += '_';
                            }
                        }
                        else
                        {
                            idValue = id + "_";
                        }
                        newElement = tmpDoc.CreateElement(string.Empty, "page", string.Empty);
                        xmlAttrId.Value = idValue;
                        newElement.Attributes.Append(xmlAttrId);
                        return newElement;
                    }

                    break;
                case "asp:textbox":
                    newElement = tmpDoc.CreateElement(string.Empty, "textBox", string.Empty);

                    XmlAttribute maxLength = tmpDoc.CreateAttribute("MaxLength");
                    XmlAttribute textMode = tmpDoc.CreateAttribute("TextMode");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "maxlength":
                                maxLength.Value = attr.Value;
                                newElement.Attributes.Append(maxLength);
                                break;
                            case "textmode":
                                textMode.Value = attr.Value;
                                newElement.Attributes.Append(textMode);
                                break;
                        }

                    }

                    return newElement;
                    break;
                case "asp:button":
                    newElement = tmpDoc.CreateElement(string.Empty, "button", string.Empty);

                    XmlAttribute buttonText = tmpDoc.CreateAttribute("Text");
                    XmlAttribute buttonClick = tmpDoc.CreateAttribute("OnClientClick");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "text":
                                buttonText.Value = attr.Value;
                                newElement.Attributes.Append(buttonText);
                                break;
                            case "onclientclick":
                                buttonClick.Value = attr.Value;
                                newElement.Attributes.Append(buttonClick);
                                break;
                        }

                    }

                    return newElement;
                    break;
                case "telerik:raddatepicker":
                    newElement = tmpDoc.CreateElement(string.Empty, "datePicker", string.Empty);
                    XmlAttribute minDate = tmpDoc.CreateAttribute("MinDate");
                    XmlAttribute maxDate = tmpDoc.CreateAttribute("MaxDate");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "mindate":
                                minDate.Value = attr.Value;
                                newElement.Attributes.Append(minDate);
                                break;
                            case "maxdate":
                                maxDate.Value = attr.Value;
                                newElement.Attributes.Append(maxDate);
                                break;
                        }

                    }
                    return newElement;
                    break;
                case "telerik:radgrid":
                    newElement = tmpDoc.CreateElement(string.Empty, "grid", string.Empty);

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        if (attr.Key.ToLower() == "id")
                        {
                            xmlAttrId.Value = attr.Value;
                            newElement.Attributes.Append(xmlAttrId);
                        }
                    }
                    return newElement;
                    break;
                case "asp:checkbox":
                    newElement = tmpDoc.CreateElement(string.Empty, "checkBox", string.Empty);

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        if (attr.Key.ToLower() == "id")
                        {
                            xmlAttrId.Value = attr.Value;
                            newElement.Attributes.Append(xmlAttrId);
                        }
                    }
                    return newElement;
                    break;
                case "asp:hyperlink":
                    newElement = tmpDoc.CreateElement(string.Empty, "hyperlink", string.Empty);
                    XmlAttribute navigateUrl = tmpDoc.CreateAttribute("Url");
                    XmlAttribute text = tmpDoc.CreateAttribute("Text");
                    XmlAttribute onclick = tmpDoc.CreateAttribute("OnClick");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "navigateurl":
                                navigateUrl.Value = attr.Value;
                                newElement.Attributes.Append(navigateUrl);
                                break;
                            case "text":
                                text.Value = attr.Value;
                                newElement.Attributes.Append(text);
                                break;
                            case "onclick":
                                onclick.Value = attr.Value;
                                newElement.Attributes.Append(onclick);
                                break;
                        }

                    }
                    return newElement;
                    break;
                case "telerik:radcombobox":
                    newElement = tmpDoc.CreateElement(string.Empty, "comboBox", string.Empty);

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        if (attr.Key.ToLower() == "id")
                        {
                            xmlAttrId.Value = attr.Value;
                            newElement.Attributes.Append(xmlAttrId);
                        }
                    }
                    return newElement;
                    break;
                case "asp:label":
                    newElement = tmpDoc.CreateElement(string.Empty, "label", string.Empty);
                    XmlAttribute lblText = tmpDoc.CreateAttribute("Text");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "text":
                                lblText.Value = attr.Value;
                                newElement.Attributes.Append(lblText);
                                break;
                        }

                    }
                    return newElement;
                    break;

                case "asp:image":
                    newElement = tmpDoc.CreateElement(string.Empty, "image", string.Empty);
                    XmlAttribute imgClick = tmpDoc.CreateAttribute("OnClick");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "onclick":
                                imgClick.Value = attr.Value;
                                newElement.Attributes.Append(imgClick);
                                break;
                        }

                    }
                    return newElement;
                    break;

                case "telerik:radnumerictextbox":
                    newElement = tmpDoc.CreateElement(string.Empty, "numericTextBox", string.Empty);
                    XmlAttribute minValue = tmpDoc.CreateAttribute("MinValue");
                    XmlAttribute maxValue = tmpDoc.CreateAttribute("MaxValue");

                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        switch (attr.Key.ToLower())
                        {
                            case "id":
                                xmlAttrId.Value = attr.Value;
                                newElement.Attributes.Append(xmlAttrId);
                                break;
                            case "minvalue":
                                minValue.Value = attr.Value;
                                newElement.Attributes.Append(minValue);
                                break;
                            case "maxvalue":
                                maxValue.Value = attr.Value;
                                newElement.Attributes.Append(maxValue);
                                break;
                        }

                    }
                    return newElement;
                    break;
                default:
                    bool tb = false;
                    foreach (ASP.Attribute attr in tag.Attributes)
                    {
                        if (attr.Value.ToLower().Contains("toolbar") && attr.Key.ToLower().Contains("class"))
                        {
                            tb = true;
                            break;
                        }
                    }
                    if (tb)
                    {
                        newElement = tmpDoc.CreateElement(string.Empty, "actions", string.Empty);
                        foreach (ASP.Tag child in tag.ChildTags)
                        {


                            XmlNode newAction = tmpDoc.CreateElement(string.Empty, "action", string.Empty);
                            XmlAttribute type = tmpDoc.CreateAttribute("Type");
                            type.Value = string.Empty;


                            foreach (ASP.Attribute actionAttr in child.Attributes)
                            {

                                if (actionAttr.Key.ToLower() == "id")
                                {
                                    xmlAttrId.Value = actionAttr.Value;
                                    newAction.Attributes.Append(xmlAttrId);
                                }
                                if (actionAttr.Value.ToLower().Contains("add"))
                                {
                                    type.Value = "add";
                                    newAction.Attributes.Append(type);
                                }
                                else if (actionAttr.Value.ToLower().Contains("edit"))
                                {
                                    type.Value = "edit";
                                    newAction.Attributes.Append(type);
                                }
                                else if (actionAttr.Value.ToLower().Contains("move"))
                                {
                                    type.Value = "move";
                                    newAction.Attributes.Append(type);
                                }
                                else if (actionAttr.Value.ToLower().Contains("remove") || actionAttr.Value.ToLower().Contains("drop"))
                                {
                                    type.Value = "drop";
                                    newAction.Attributes.Append(type);
                                }
                            }
                            if (xmlAttrId.Value != string.Empty && type.Value != string.Empty)
                            {
                                //Console.WriteLine(newAction.Attributes[0].Name + " = " + newAction.Attributes[0].Value + "  " + newAction.Attributes[1].Name + " = " + newAction.Attributes[1].Value);
                                newElement.AppendChild(newElement.OwnerDocument.ImportNode(newAction, true));
                            }
                            //traiter action.



                        }
                        return newElement;
                    }
                    else
                        Console.WriteLine("unreferenced node : " + tag.Name);
                    break;
            }

            XmlNode unknownNode = tmpDoc.CreateElement(string.Empty, "unreferencedTag", string.Empty);
            XmlAttribute unknownkId = tmpDoc.CreateAttribute("ID");

            unknownkId.Value = "Unreferenced_Tag" + unhandled;
            unhandled++;
            unknownNode.Attributes.Append(unknownkId);
            unknownNode.InnerXml = "<![CDATA[" + tagToString(tag) + "]]>";
            return unknownNode;

        }

        private string tagToString(ASP.Tag tag)
        {
            StringBuilder s = new StringBuilder();

            if (tag.TagType != TagType.Text)
                s.Append("<" + tag.Name + " ");
            else
                s.Append(tag.Name);

            foreach (ASP.Attribute attr in tag.Attributes)
            {
                s.Append(attr.Key);
                s.Append("=\"");
                s.Append(attr.Value);
                s.Append("\" ");
            }
            if (tag.TagType != TagType.Text)
                s.Append(">");
            if (tag.HasChildTags)
            {
                foreach (ASP.Tag child in tag.ChildTags)
                {

                    s.Append(tagToString(child));
                }
            }
            if (tag.TagType != TagType.Text)
                s.Append("</" + tag.Name + ">");
            return s.ToString();
        }

        public void FindDivs(ASP.Tag tag, List<ASP.Tag> tl)
        {
            foreach (ASP.Tag child in tag.ChildTags)
            {
                if (child.TagType == ASP.TagType.Open)
                {
                    switch (child.Name.ToLower())
                    {


                        case "tr":
                        case "table":
                        case "td":
                        case "div":
                        case "telerik:radtabstrip":
                        case "telerik:radtab":
                        case "asp:textbox":
                        case "telerik:raddatepicker":
                        case "telerik:radgrid":
                        case "asp:checkbox":
                        case "asp:hyperlink":
                        case "telerik:radcombobox":
                        case "asp:label":
                        case "telerik:radnumerictextbox":
                        case "asp:button":
                        case "asp:image":
                            break;

                        default:
                            tl.Add(child);
                            //FindBlocks(child,tl);
                            break;
                    }
                }
            }
        }

        public void FindBlocks(ASP.Tag tag, List<ASP.Tag> tl)
        {
            foreach (ASP.Tag child in tag.ChildTags)
            {
                if (child.TagType == ASP.TagType.Open)
                {
                    switch (child.Name.ToLower())
                    {

                        case "div":
                            //tl.Add(child);
                            FindBlocks(child, tl);
                            break;
                        case "table":
                            FindBlocks(child, tl);
                            break;
                        case "td":
                            FindBlocks(child, tl);
                            break;

                        case "tr":
                            //case "div":
                            List<ASP.Tag> table = new List<Tag>();
                            FindAllTags(child, table, "table", false);
                            if (table.Count > 0)
                                FindBlocks(child, tl);
                            else
                                tl.Add(child);
                            //FindBlocks(child,tl);
                            break;

                        case "telerik:radtabstrip":
                        case "telerik:radtab":
                        case "tabs":
                            break;

                        default:
                            tl.Add(child);
                            //FindBlocks(child,tl);
                            break;
                    }
                }
            }
        }


        public XmlNode getBlock(ASP.Tag tag)
        {
            XmlDocument tmpDoc = new XmlDocument();
            XmlNode newElement = tmpDoc.CreateElement(string.Empty, "block", string.Empty);
            List<ASP.Tag> cl = new List<ASP.Tag>();
            if (tag.Name.ToLower() == "tr")
            {
                FindControls(tag, cl);

                foreach (ASP.Tag child in cl)
                {
                    try
                    {
                        newElement.AppendChild(newElement.OwnerDocument.ImportNode(getXml(child, tmpDoc), true));

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("ERROR : Trying to append empty node : " + child.Name);
                    }
                }
            }
            else
                newElement.AppendChild(newElement.OwnerDocument.ImportNode(getXml(tag, tmpDoc), true));
            return newElement;
        }

        /* Gets all the controls of a pageview */
        public XmlNode ParsePageView(ASP.Tag tag)
        {
            List<ASP.Tag> tl = new List<ASP.Tag>();

            XmlDocument tmpDoc = new XmlDocument();
            XmlNode newElement = null;

            if (tag.Name.ToLower() == "telerik:radpageview" && tag.TagType == ASP.TagType.Open)
            {
                //get all the useful controls in the pageview and parse them

                /*
                 Possible contained tags (all lowered) :
                 * telerik:radmultipage
                 * asp:texbox
                 * class="toolbar" -> à parser en stand alone
                 * telerik:raddatepicker
                 * telerik:radgrid
                 * asp:checkbox
                 * asp:hyperlink
                 * telerik:radcombobox
                 * telerik:radnumerictextbox
                 * asp:label
                 */
                newElement = getXml(tag, tmpDoc);
                //FindDivs(tag, tl);
                FindBlocks(tag, tl);
                //FindControls(tag, tl);

                foreach (ASP.Tag child in tl)
                {
                    try
                    {
                        XmlNode block = getBlock(child);
                        if (block.HasChildNodes)
                            newElement.AppendChild(newElement.OwnerDocument.ImportNode(block, true));
                        //newElement.AppendChild(newElement.OwnerDocument.ImportNode(getXml(child, tmpDoc), true));

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("ERROR : Trying to append empty node : " + child.Name);
                    }
                }

            }
            else
            {
                Console.WriteLine("Not a PageView");
            }
            return newElement;
        }

        /* Called from outside of the package to transform a 3.5 aspx to an xml document */
        public XmlDocument Parse35MultiPage(ASP.Tag tag)
        {
            if (tag != null)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDeclaration);
                doc.AppendChild(ParseMultiPage(tag, doc));
                return doc;
            }
            return null;

        }

        /* Returns an XmlNode containing the informations of a multipage in XML format */
        public XmlNode ParseMultiPage(ASP.Tag tag, XmlDocument tmpDoc)
        {
            XmlNode newElement = null;
            if (tag.Name.ToLower() == "telerik:radmultipage" && tag.TagType == TagType.Open)
            {

                string id = string.Empty;

                foreach (ASP.Attribute attr in tag.Attributes)
                {
                    if (attr.Key.ToLower() == "id")
                    {
                        id = attr.Value;
                        break;
                    }

                }
                newElement = tmpDoc.CreateElement(string.Empty, "multipage", string.Empty);
                XmlAttribute xmlAttr = tmpDoc.CreateAttribute("ID");
                xmlAttr.Value = id;
                newElement.Attributes.Append(xmlAttr);


                //get all the pageviews parse each one of them : ParsePageView(currentPageView);
                List<ASP.Tag> pageviews = new List<ASP.Tag>();
                FindAllTags(tag, pageviews, "telerik:radpageview", true);

                foreach (ASP.Tag child in pageviews)
                {
                    try
                    {
                        newElement.AppendChild(newElement.OwnerDocument.ImportNode(ParsePageView(child), true));
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("ERROR : Trying to insert a null node : " + child.Name);
                    }
                }

            }
            else
            {
                Console.WriteLine("Not a multipage");
            }
            return newElement;
        }

        public XmlDocument ParseAspx(string path)
        {
            unhandled = 1;
            ASP.Document root = new ASP.Document(File.ReadAllText(path));
            return Parse35MultiPage(FindFirstMultiPage(root));
        }

    }
}
