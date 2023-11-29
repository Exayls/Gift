using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Microsoft.Extensions.Logging;
using System;
using System.Xml;

namespace Gift.XmlUiParser.FileParser
{
    public class XmlFileParser : IXMLFileParser
    {
        private readonly IUIElementRegister _uielementRegister;
        private GiftUI? giftUI = null;
        private readonly ILogger<IXMLFileParser> _logger;

        public XmlFileParser(IUIElementRegister elementRegister, ILogger<IXMLFileParser> logger)
        {
            _uielementRegister = elementRegister;
            _logger = logger;
        }





        private void SelectContainer(UIElement uiElement, XmlElement element)
        {
            if (giftUI == null)
            {
                return;
            }
            if (uiElement is Container container)
            {
                if (element.GetAttribute("selectableContainer") == "true")
                {
                    giftUI.SelectableContainers.Add(container);
                }
                if (element.GetAttribute("selectedContainer") == "true")
                {
                    giftUI.SelectedContainer = container;
                }
            }
        }

        private void SelectElement(UIElement uiElement, XmlElement element, Container container)
        {
            if (element.GetAttribute("selectableElement") == "true")
            {
                container.SelectableElements.Add(uiElement);
            }
            if (element.GetAttribute("selectedElement") == "true")
            {
                container.SelectedElement = uiElement;
            }
        }

        public UIElement ParseUIFileUsingBuilders(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            if (xmlDoc.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            return ParseUIElementRecBuilders(xmlDoc.DocumentElement, null);
        }

        private UIElement ParseUIElementRecBuilders(XmlElement element, Container? parent)
        {
            UIElement component;


            component = CreateGenericComponentBuilders(element);

            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is not XmlElement) { continue; }
                if (component is not Container container)
                {
                    throw new Exception("Only container component can have childs");
                }

                if (childNode is XmlElement childElement)
                {
                    UIElement childComponent = ParseUIElementRecBuilders(childElement, container);
                    container.AddUnselectableChild(childComponent);
                    SelectElement(childComponent, childElement, container);
                    SelectContainer(childComponent, childElement);
                }
            }
            return component;
        }

        private UIElement CreateGenericComponentBuilders(XmlElement element)
        {
            string componentName = element.Name;
            var builder = CreateBuilder(componentName);
            UIElement uiElement = ConstructElement(element, builder);
            return uiElement;
        }

        private IBuilder<UIElement> CreateBuilder(string componentName)
        {
            var builderType = _uielementRegister.GetBuilder(componentName);
            var builder = (IBuilder<UIElement>)builderType.GetConstructors()[0].Invoke(new object[] { });
            return builder;
        }

        private UIElement ConstructElement(XmlElement element, IBuilder<UIElement> builder)
        {
            XmlAttributeCollection attributes = element.Attributes;
            foreach (XmlAttribute attribute in attributes)
            {
                AddParameterIfPossible(builder, attribute);
            }
            return builder.Build();
        }

        private void AddParameterIfPossible(IBuilder<UIElement> builder, XmlAttribute attribute)
        {
            var attributeName = attribute.Name;
            var method = GetMethod(builder, attributeName);
            if (method == null)
            {
                return;
            }
            var attributeValue = attribute.InnerText;
            ExecBuilderMethod(builder, method, attributeValue);
        }

        private IBuilder<UIElement>? ExecBuilderMethod(IBuilder<UIElement> builder, Func<IBuilder<UIElement>, object, IBuilder<UIElement>> method, string attributeValue)
        {
            try
            {
                return method(builder, attributeValue);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e, $"Can't execute the method: {method} with parameter: {attributeValue}");
            }
            return null;
        }

        private Func<IBuilder<UIElement>, object, IBuilder<UIElement>>? GetMethod(IBuilder<UIElement> builder, string attributeName)
        {
                _logger.LogDebug($"attributeNaisaueiteirueiuss not registered");
            try
            {
                return _uielementRegister.GetMethod(builder.GetType(), attributeName);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e, $"attributeName {attributeName} is not registered");
            }
            return null;
        }
    }
}

