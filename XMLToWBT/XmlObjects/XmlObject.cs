using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XMLToWBT.XmlObjects
{
    public abstract class XmlObject
    {
        // Every XML tag that is ridden is supposed to have an ID
        protected string ID { get; set; }
        // Defines whether the XmlObject is an opening or a closing one
        // true : opening
        // false : closing
        protected bool type { get; set; }

        //AspxOpening is the opening Tag (used depending on type)
        protected List<string> AspxOpening { get; set; }
        //Used when others XmlObjects have to insert code within it.
        protected List<string> AspxContent { get; set; }
        //AspxOpening is the closing tag (used depending on type)
        protected List<string> AspxClosing { get; set; }

        //Defines the indentation of the current XmlObject
        public string spaces { get; set; }

        //Aspx generated and inserted in the generatedAspxDestinationNode's children (ahead of the list or not depending on a parameter)
        protected XmlObject generatedAspx { get; set; }
        //The target Node in the datastructure that will receive the generated Node
        public Node<XmlObject> generatedAspxDestinationNode { get; set; }


        public XmlObject()
        {
            this.type = true;
            AspxOpening = new List<string>();
            AspxContent = new List<string>();
            AspxClosing = new List<string>();
            spaces = "";
        }

        
        public abstract void setId(string _id);

        public void setGeneratedAspxDestinationNode(Node<XmlObject> n)
        {
            generatedAspxDestinationNode = n;
        }

        public void installGeneratedAspx(bool installAhead)
        {
            if (generatedAspxDestinationNode != null)
            {
                Node<XmlObject> newNode = new Node<XmlObject>("generatedAspx", generatedAspxDestinationNode, generatedAspx);
                newNode._element.spaces = this.spaces+"  ";
                if (installAhead)
                    generatedAspxDestinationNode.addChildAhead(newNode);
                else
                    generatedAspxDestinationNode.addChild(newNode);

            }
        }

        public void addContent(string content)
        {
            AspxContent.Add(content);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in AspxOpening)
            {
                if (Regex.IsMatch(s, "^(\\s*<)"))
                    sb.Append(this.spaces);
                sb.Append(s);
            }

            foreach (string s in AspxContent)
            {
                if (Regex.IsMatch(s, "^(\\s*<)"))
                    sb.Append(this.spaces);
                sb.Append(s);
            }
            sb.Append(spaces);
            foreach (string s in AspxClosing)
            {
                if (Regex.IsMatch(s, "^(\\s*<)"))
                    sb.Append(this.spaces);
                sb.Append(s);
            }
            return sb.ToString();
        }

        public void concatGeneratedAspx(XmlObject aspx)
        {
            AspxContent.Add(aspx.ToString());
        }

        #region Interdependant Methods

        public virtual void prepareTabStrip(string _orientation)
        {
            //Only used in TabStrip.cs
        }

        public virtual void preparePageView(string _index)
        {
            //Only used in PageView.cs
        }

        public virtual void prepareTab(string _css, string _index)
        {
            //Only used in Tab.cs
        }

        public virtual void prepareButton(string _text, string _onclick)
        {
            //Only used in Button.cs    
        }

        public virtual void prepareDatePicker(string _minDate, string _maxDate)
        {
            //Only used in DatePicker.cs
        }

        public virtual void prepareEditor(string _height, string _width)
        {
            //Only used in Editor.cs
        }

        public virtual void prepareHyperlink(string _text, string _url, string _onclick)
        {
            //Only used in Hyperlink.cs and Label.cs
        }

        public virtual void prepareImage(string _onclick)
        {
            //Only used in Image.cs
        }

        public virtual void prepareLabel(string _text)
        {
            //Only used in Label.cs
        }

        public virtual void prepareNumericTextBox(string _minValue, string _maxValue)
        {
            //Only used in NumericTextBox.cs
        }

        public virtual void prepareRadioButton(string _onclick)
        {
            //Only used in RadioButton.cs
        }

        public virtual void prepareTextBox(string _textMode, string _maxLength)
        {
            //Only used in TextBox.cs
        }

        public virtual void prepareGeneratedAspx(params string[] args)
        {

        }




        #endregion
    }
}
