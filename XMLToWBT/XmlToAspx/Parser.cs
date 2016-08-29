using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using XMLToWBT.DataStructure;
using XMLToWBT.Factories;
using XMLToWBT.XmlObjects;
using XMLToWBT.XmlObjects.Containers;

namespace XMLToWBT.XmlToAspx
{
    public class Parser
    {

        private Tree<XmlObject> tree { get; set; }
        private XmlObjectFactory fact = new XmlObjectFactory();

        public Parser()
        {
            tree = new Tree<XmlObject>();
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            string s = "";
            if (args.Severity == XmlSeverityType.Warning)
                s += "WARNING: ";
            else if (args.Severity == XmlSeverityType.Error)
                s += "ERROR: ";

            throw new Exception(s + args.Message);
        }


        public void validate(XmlDocument doc)
        {
            if (doc.Schemas.Count == 0)
            {
                XmlTextReader reader = new XmlTextReader("XmlObjects/migration.xsd");
                XmlSchema schema = XmlSchema.Read(reader, ValidationCallback);
                doc.Schemas.Add(schema);
            }
            doc.Validate(ValidationCallback);
        }

        public string parseXml(XmlDocument doc)
        {

            try
            {



                validate(doc);


                tree = new Tree<XmlObject>();
                parse(doc, tree, true, 0, 2);
                List<Node<XmlObject>> flatTree = new List<Node<XmlObject>>();
                prepareTree(tree, flatTree);
                fullFillTree(flatTree);
                clearTree();
                return tree.ToString();
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        private string getSpaces(int spaces)
        {
            string s = "";

            for (int i = 0; i < spaces; i++)
                s = s + " ";

            return s;
        }
        private void parse(XmlNode doc, Node<XmlObject> n, bool firstMultiPage, int pageViewCounter, int spaces)
        {
            Node<XmlObject> currentNode = null;
            foreach (XmlNode node in doc.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    switch (node.Name.ToLower())
                    {
                        case "multipage":
                            pageViewCounter = 0;
                            XmlObject mp = fact.Create("multipage");
                            mp.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                {
                                    mp.setId(attr.Value);

                                    if (firstMultiPage)
                                        mp.prepareGeneratedAspx("VerticalLeft");
                                    else
                                        mp.prepareGeneratedAspx(string.Empty);
                                }
                            }
                            mp.setGeneratedAspxDestinationNode(n);
                            currentNode = new Node<XmlObject>("node:MultiPage", n, mp);
                            mp.installGeneratedAspx(true);
                            n.addChild(currentNode);
                            break;

                        case "page":

                            bool isCss = false;
                            XmlObject pv = fact.Create("pageview");
                            pv.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                {
                                    pv.setId(attr.Value);
                                    pv.preparePageView(pageViewCounter.ToString());


                                }
                                if (attr.Name.ToLower() == "css")
                                {
                                    isCss = true;
                                    pv.prepareGeneratedAspx(attr.Value, pageViewCounter.ToString());
                                    pageViewCounter++;
                                }

                            }
                            if (!isCss)
                            {
                                pv.prepareGeneratedAspx(string.Empty, pageViewCounter.ToString());
                                pageViewCounter++;
                            }
                            pv.setGeneratedAspxDestinationNode(n._element.generatedAspxDestinationNode.Children[0]);
                            currentNode = new Node<XmlObject>("node:PageView", n, pv);
                            pv.installGeneratedAspx(false);
                            n.addChild(currentNode);
                            break;
                        case "actions":
                            XmlObject actions = fact.Create("actions");
                            actions.spaces = getSpaces(spaces);

                            currentNode = new Node<XmlObject>("node:actions", n, actions);
                            n.addChild(currentNode);
                            break;
                        case "block":
                            XmlObject block = fact.Create("block");
                            block.spaces = getSpaces(spaces);

                            currentNode = new Node<XmlObject>("node:block", n, block);
                            n.addChild(currentNode);
                            break;
                        case "action":
                            XmlAttribute atr = null;
                            XmlAttribute id = null;
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "type")
                                    atr = attr;

                                if (attr.Name.ToLower() == "id")
                                    id = attr;
                            }
                            if (atr != null && id != null)
                            {
                                switch (atr.Value.ToLower())
                                {

                                    case "add":
                                        XmlObject add = fact.Create("add");
                                        add.setId(id.Value);
                                        add.spaces = getSpaces(spaces);

                                        currentNode = new Node<XmlObject>("node:add", n, add);
                                        n.addChild(currentNode);
                                        break;
                                    case "drop":
                                        XmlObject drop = fact.Create("drop");
                                        drop.setId(id.Value);
                                        drop.spaces = getSpaces(spaces);

                                        currentNode = new Node<XmlObject>("node:drop", n, drop);
                                        n.addChild(currentNode);
                                        break;
                                    case "edit":
                                        XmlObject edit = fact.Create("edit");
                                        edit.setId(id.Value);
                                        edit.spaces = getSpaces(spaces);

                                        currentNode = new Node<XmlObject>("node:edit", n, edit);
                                        n.addChild(currentNode);
                                        break;
                                    case "move":
                                        XmlObject move = fact.Create("move");
                                        move.setId(id.Value);
                                        move.spaces = getSpaces(spaces);

                                        currentNode = new Node<XmlObject>("node:move", n, move);
                                        n.addChild(currentNode);
                                        break;
                                }
                            }
                            break;
                        case "button":
                            XmlObject button = fact.Create("button");
                            button.spaces = getSpaces(spaces);
                            string text = "click me", onclick = "javascript;;";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    button.setId(attr.Value);
                                if (attr.Name.ToLower() == "text")
                                    text = attr.Value;
                                if (attr.Name.ToLower() == "onclick")
                                    onclick = attr.Value;

                            }
                            button.prepareButton(text, onclick);
                            currentNode = new Node<XmlObject>("node:button", n, button);
                            n.addChild(currentNode);
                            break;
                        case "caption":
                            XmlObject caption = fact.Create("caption");
                            caption.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    caption.setId(attr.Value);
                            }
                            currentNode = new Node<XmlObject>("node:caption", n, caption);
                            n.addChild(currentNode);
                            break;
                        case "checkbox":
                            XmlObject checkbox = fact.Create("checkbox");
                            checkbox.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    checkbox.setId(attr.Value);
                            }
                            currentNode = new Node<XmlObject>("node:checkbox", n, checkbox);
                            n.addChild(currentNode);
                            break;
                        case "combobox":
                            XmlObject combobox = fact.Create("combobox");
                            combobox.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    combobox.setId(attr.Value);
                            }
                            currentNode = new Node<XmlObject>("node:combobox", n, combobox);
                            n.addChild(currentNode);
                            break;

                        case "datepicker":
                            XmlObject dp = fact.Create("datepicker");
                            dp.spaces = getSpaces(spaces);
                            string minDate = "08/05/1945", maxDate = "16/12/1991";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    dp.setId(attr.Value);
                                if (attr.Name.ToLower() == "mindate")
                                    minDate = attr.Value;
                                if (attr.Name.ToLower() == "maxdate")
                                    maxDate = attr.Value;

                            }
                            dp.prepareDatePicker(minDate, maxDate);
                            currentNode = new Node<XmlObject>("node:datepicker", n, dp);
                            n.addChild(currentNode);
                            break;
                        case "editor":
                            XmlObject editor = fact.Create("editor");
                            editor.spaces = getSpaces(spaces);
                            string height = "100%", width = "100%";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    editor.setId(attr.Value);
                                if (attr.Name.ToLower() == "height")
                                    height = attr.Value;
                                if (attr.Name.ToLower() == "width")
                                    width = attr.Value;

                            }
                            editor.prepareEditor(height, width);
                            currentNode = new Node<XmlObject>("node:editor", n, editor);
                            n.addChild(currentNode);
                            break;
                        case "grid":
                            XmlObject grid = fact.Create("grid");
                            grid.spaces = getSpaces(spaces);
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    grid.setId(attr.Value);
                            }
                            currentNode = new Node<XmlObject>("node:grid", n, grid);
                            n.addChild(currentNode);
                            break;
                        case "hyperlink":
                            XmlObject hl = fact.Create("hyperlink");
                            hl.spaces = getSpaces(spaces);
                            string hlText = "I am a link, and i am very happy to be empty", url = "#", hlOnclick = "javascript;;";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    hl.setId(attr.Value);
                                if (attr.Name.ToLower() == "url")
                                    url = attr.Value;
                                if (attr.Name.ToLower() == "text")
                                    hlText = attr.Value;
                                if (attr.Name.ToLower() == "onclick")
                                    hlOnclick = attr.Value;

                            }
                            hl.prepareHyperlink(hlText, url, hlOnclick);
                            currentNode = new Node<XmlObject>("node:hyperlink", n, hl);
                            n.addChild(currentNode);
                            break;
                        case "image":
                            XmlObject image = fact.Create("image");
                            image.spaces = getSpaces(spaces);
                            string imgOnclick = "javascript;;";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    image.setId(attr.Value);
                                if (attr.Name.ToLower() == "onclick")
                                    imgOnclick = attr.Value;
                            }
                            image.prepareImage(imgOnclick);
                            currentNode = new Node<XmlObject>("node:image", n, image);
                            n.addChild(currentNode);
                            break;
                        case "label":
                            
                                XmlObject lbl = fact.Create("label");
                                lbl.spaces = getSpaces(spaces);
                                string lblText = "Bonjour jeune asticot";
                                foreach (XmlAttribute attr in node.Attributes)
                                {
                                    if (attr.Name.ToLower() == "id")
                                        lbl.setId(attr.Value);
                                    if (attr.Name.ToLower() == "text")
                                        lblText = attr.Value;
                                }
                                lbl.prepareLabel(lblText);
                                currentNode = new Node<XmlObject>("node:label", n, lbl);
                                n.addChild(currentNode);
                            
                            break;
                        case "numerictextbox":
                            XmlObject ntb = fact.Create("numerictextbox");
                            ntb.spaces = getSpaces(spaces);
                            string minValue = "-42", maxValue = "1000";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    ntb.setId(attr.Value);
                                if (attr.Name.ToLower() == "minvalue")
                                    minValue = attr.Value;
                                if (attr.Name.ToLower() == "maxvalue")
                                    maxValue = attr.Value;

                            }
                            ntb.prepareNumericTextBox(minValue, maxValue);
                            currentNode = new Node<XmlObject>("node:numerictextbox", n, ntb);
                            n.addChild(currentNode);
                            break;
                        case "radiobutton":
                            XmlObject rb = fact.Create("radiobutton");
                            rb.spaces = getSpaces(spaces);
                            string rbOnclick = "javascript;;";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                    rb.setId(attr.Value);
                                if (attr.Name.ToLower() == "onclick")
                                    rbOnclick = attr.Value;
                            }
                            rb.prepareRadioButton(rbOnclick);
                            currentNode = new Node<XmlObject>("node:radiobutton", n, rb);
                            n.addChild(currentNode);
                            break;
                        case "textbox":
                            XmlObject tb = fact.Create("textbox");
                            tb.spaces = getSpaces(spaces);
                            string maxLength = "255", textMode = "inline";
                            foreach (XmlAttribute attr in node.Attributes)
                            {

                                if (attr.Name.ToLower() == "id")
                                    tb.setId(attr.Value);
                                if (attr.Name.ToLower() == "maxlength")
                                    maxLength = attr.Value;
                                if (attr.Name.ToLower() == "textmode")
                                    textMode = attr.Value;

                            }
                            tb.prepareTextBox(maxLength, textMode);
                            currentNode = new Node<XmlObject>("node:textbox", n, tb);
                            n.addChild(currentNode);
                            break;
                        case "unreferencedtag":
                            XmlObject un = fact.Create("unreferencedtag");
                            un.addContent(node.InnerText+"\n");
                            currentNode = new Node<XmlObject>("node:unreferencedTag", n, un);
                            n.addChild(currentNode);
                            break;
                        default:
                            XmlObject def = fact.Create("label");
                            def.spaces = getSpaces(spaces);
                            string defText = "";
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.ToLower() == "id")
                                {
                                    def.setId(attr.Value);
                                    defText = "unhandled tag :" + attr.Value;
                                }
                            }


                            def.prepareLabel(defText);
                            currentNode = new Node<XmlObject>("node:default", n, def);
                            n.addChild(currentNode);
                            break;
                    }
                    parse(node, currentNode, false, pageViewCounter, spaces + 2);
                }
            }
        }

        private void prepareTree(Node<XmlObject> n, List<Node<XmlObject>> flattenTree)
        {

            foreach (Node<XmlObject> child in n.Children)
            {
                flattenTree.Add(child);
                prepareTree(child, flattenTree);
            }
        }


        private void clearTree()
        {
            foreach (Node<XmlObject> child in tree.Children)
            {
                for (int i = child.Children.Count - 1; i >= 0; i--)
                {
                    child.removeChild(child.Children[i]);
                }
            }
        }

        private void fullFillTree(List<Node<XmlObject>> flatTree)
        {
            for (int i = flatTree.Count - 1; i >= 0; i--)
            {
                foreach (Node<XmlObject> child in flatTree[i].Children)
                {
                    flatTree[i]._element.concatGeneratedAspx(child._element);
                }
            }
        }

    }
}
