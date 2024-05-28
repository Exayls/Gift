using Gift.Domain.Builders.UIModel;
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
        private readonly ILogger<IXMLFileParser> _logger;

        public XmlFileParser(IUIElementRegister elementRegister, ILogger<IXMLFileParser> logger)
        {
            _uielementRegister = elementRegister;
            _logger = logger;
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

        public UIElement ParseUIFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            if (xmlDoc.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            return ParseUIElementRec(xmlDoc.DocumentElement);
        }

        private UIElement ParseUIElementRec(XmlElement element)
        {
            IBuilder<UIElement> componentBuilder;

            componentBuilder = CreateElementBuilder(element);
            _logger.LogTrace($"element {componentBuilder} created");

            UIElement uIElement = componentBuilder.Build();

            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is not XmlElement)
                {
                    continue;
                }
                if (componentBuilder is not IBuilder<Container> containerBuilder)
                {
                    throw new UncompatibleUIElementException(
                        $"component {componentBuilder} must be container to contain childs");
                }

                if (childNode is XmlElement childElement)
                {
                    UIElement childComponent = ParseUIElementRec(childElement);
                    var container = (Container)uIElement;
                    if (container.IsSelectableContainer)
                    {
                        container.AddSelectableChild(childComponent);
                    }
                    else
                    {
                        container.Add(childComponent);
                    }
                }
            }

            return uIElement;
        }

        private IBuilder<UIElement> CreateElementBuilder(XmlElement element)
        {
            var builder = CreateBuilder(element.Name);
            IBuilder<UIElement> uiElementBuilder = ConstructElement(element, builder);
            return uiElementBuilder;
        }

        private IBuilder<UIElement> CreateBuilder(string componentName)
        {
            var builderType = _uielementRegister.GetBuilder(componentName);
            var builder = (IBuilder<UIElement>)builderType.GetConstructors()[0].Invoke(new object[] { });
            return builder;
        }

        private IBuilder<UIElement> ConstructElement(XmlElement element, IBuilder<UIElement> builder)
        {
            XmlAttributeCollection attributes = element.Attributes;
            foreach (XmlAttribute attribute in attributes)
            {
                AddParameterIfPossible(builder, attribute);
            }
            return builder;
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

        private IBuilder<UIElement>? ExecBuilderMethod(IBuilder<UIElement> builder,
                                                       Func<IBuilder<UIElement>, object, IBuilder<UIElement>> method,
                                                       string attributeValue)
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

        private Func<IBuilder<UIElement>, object, IBuilder<UIElement>>? GetMethod(IBuilder<UIElement> builder,
                                                                                  string attributeName)
        {
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
