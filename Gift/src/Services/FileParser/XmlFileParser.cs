using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gift.src.Services.FileParser
{
    public class XmlFileParser : IXMLFileParser
    {
        public IGiftUI ParseUIFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            if (xmlDoc.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            return ParseUIElement(xmlDoc.DocumentElement);
        }

        private IGiftUI ParseUIElement(XmlElement element)
        {
            IGiftUI giftui = new GiftUI();

            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is XmlElement childElement)
                {
                    IUIElement childComponent = ParseUIElementRec(childElement);
                    giftui.AddChild(childComponent);
                }
            }
            return giftui;
        }


        private IUIElement ParseUIElementRec(XmlElement element)
        {
            IUIElement component;

            component = CreateUIElement(element);

            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is not XmlElement) { continue; }
                if (component is not IContainer container)
                {
                    throw new Exception("component is not container");
                }
                AddChild(container, childNode);
            }

            return component;
        }

        private static IUIElement CreateUIElement(XmlElement element)
        {
            IUIElement component;

            IBorder border = GetBorder(element);

            switch (element.Name)
            {
                case "Vstack":
                    component = new VStackBuilder().WithBorder(border).Build();
                    break;
                case "Hstack":
                    component = new HStackBuilder().WithBorder(border).Build();
                    break;
                case "Label":
                    component = new LabelBuilder().WithText(element.InnerText).Build();
                    break;
                // Add more cases for other UI components as needed

                default:
                    throw new NotSupportedException("Unsupported UI component: " + element.Name);
            }
            return component;
        }

        private static IBorder GetBorder(XmlElement element)
        {
            IBorder border;
            string borderOption = element.Attributes.GetNamedItem("BorderOption")?.Value ?? "default";
            int thickness;
            int.TryParse(element.Attributes.GetNamedItem("thickness")?.Value ?? "1", out thickness);

            switch (borderOption)
            {
                case "default":
                    border = new NoBorder();
                    break;
                case "simple":
                    border = new Border(thickness, BorderOption.Simple);
                    break;
                case "heavy":
                    border = new Border(thickness, BorderOption.Heavy);
                    break;
                default:
                    border = new Border(thickness, BorderOption.GetBorderCharsFromFile(borderOption));
                    break;
            }
            return border;
        }

        private void AddChild(IContainer container, XmlNode childNode)
        {
            if (childNode is XmlElement childElement)
            {
                IUIElement childComponent = ParseUIElementRec(childElement);
                container.AddChild(childComponent);
            }
        }

    }
}
