using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToWBT.XmlObjects;
using XMLToWBT.XmlObjects.Actions;
using XMLToWBT.XmlObjects.Containers;
using XMLToWBT.XmlObjects.Content;

namespace XMLToWBT.Factories
{
    public class XmlObjectFactory : Factory<XmlObject>, FactoryInterface<XmlObject>
    {
        public XmlObject Create(string key)
        {
            switch (key.ToLower())
            {
                case "block":
                    return new Block();
                    break;
                case "actions":
                    return new Actions();
                    break;
                case "multipage":
                    return new Multipage();
                    break;
                case "pageview":
                    return new PageView();
                    break;
                case "tabstrip":
                    return new TabStrip();
                    break;
                case "add":
                    return new Add();
                    break;
                case "drop":
                    return new Drop();
                    break;
                case "edit":
                    return new Edit();
                    break;
                case "move":
                    return new Move();
                    break;
                case "button":
                    return new Button();
                    break;
                case "caption":
                    return new Caption();
                    break;
                case "checkbox":
                    return new CheckBox();
                    break;
                case "combobox":
                    return new ComboBox();
                    break;
                case "datepicker":
                    return new DatePicker();
                    break;
                case "editor":
                    return new Editor();
                    break;
                case "grid":
                    return new Grid();
                    break;
                case "hyperlink":
                    return new Hyperlink();
                    break;
                case "image":
                    return new Image();
                    break;
                case "label":
                    return new Label();
                    break;
                case "numerictextbox":
                    return new NumericTextBox();
                    break;
                case "radiobutton":
                    return new RadioButton();
                    break;
                case "tab":
                    return new Tab();
                    break;
                case "textbox":
                    return new TextBox();
                    break;
                case "unreferencedtag":
                    return new UnreferencedTag();
                    break;
                default:
                    return null;
                    break;

            }
        }
    }
}
