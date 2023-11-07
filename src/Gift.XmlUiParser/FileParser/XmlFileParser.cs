using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
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

        public GiftUI ParseUIFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            if (xmlDoc.DocumentElement == null)
            {
                throw new NullReferenceException();
            }
            return ParseUIElement(xmlDoc.DocumentElement);
        }

        private GiftUI ParseUIElement(XmlElement element)
        {
            GiftUI giftui = new GiftUIBuilder().Build();
            giftUI = giftui;
            foreach (XmlNode childNode in element.ChildNodes)
            {
                AddChild(giftui, childNode);
            }
            return giftui;
        }

        private UIElement ParseUIElementRec(XmlElement element, Container parent)
        {
            UIElement component;


            component = CreateGenericComponent(element, parent);

            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode is not XmlElement) { continue; }
                if (component is not Container container)
                {
                    throw new Exception("component is not container");
                }
                AddChild(container, childNode);
            }
            return component;
        }

        private void AddChild(Container container, XmlNode childNode)
        {
            if (childNode is XmlElement childElement)
            {
                UIElement childComponent = ParseUIElementRec(childElement, container);
                container.AddUnselectableChild(childComponent);
                SelectElement(childComponent, childElement, container);
                SelectContainer(childComponent, childElement);
            }
        }


        private UIElement CreateGenericComponent(XmlElement element, Container parent)
        {
            string componentName = element.Name;
            Type componentType = GetTypeByName(componentName);

            ConstructorInfo[] constructors = GetConstructor(componentName, componentType);

            UIElement uiElement = ConstructElementViaConstructor(element, componentName, constructors);

            return uiElement;
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

        private static UIElement ConstructElementViaConstructor(XmlElement element, string componentName, ConstructorInfo[] constructors)
        {
            ConstructorInfo? biggestConstructor = null;
            int constructorLength = 0;
            foreach (var constructor in constructors)
            {
                ParameterInfo[] tmpParameters = constructor.GetParameters();
                if (tmpParameters.Length > constructorLength)
                {
                    constructorLength = tmpParameters.Length;
                    biggestConstructor = constructor;
                }
            }
            if (biggestConstructor is null)
            {
                throw new Exception();
            }

            ParameterInfo[] parameters = biggestConstructor.GetParameters();
            object?[] args = new object[parameters.Length];

            var argsValues = CreateArgs(element, parameters, args);
            object componentInstance = biggestConstructor.Invoke(argsValues);

            if (componentInstance is not UIElement uiElement)
            {
                throw new Exception("Unknown component does not implement UIElement: " + componentName);
            }

            return uiElement;
        }

        private static object?[] CreateArgs(XmlElement element, ParameterInfo[] parameters, object?[] args)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                object? arg = null;
                ParameterInfo parameter = parameters[i];
                Type parameterType = parameter.ParameterType;
                if (parameter.Name == "text")
                {
                    arg = element.InnerText;
                }
                else if (parameterType == typeof(IBorder))
                {
                    arg = GetBorder(element);
                }
                else if (parameterType == typeof(Color))
                {
                    if (parameter.Name == "frontColor")
                    {
                        arg = GetForeGroundColor(element);
                    }
                    else if (parameter.Name == "backColor")
                    {
                        arg = GetBackGroundColor(element);
                    }
                    else
                    {
                        arg = Color.Default;
                    }
                }
                else if (parameterType == typeof(IScreenDisplayFactory))
                {
                    arg = new ScreenDisplayFactory();
                }
                else if (parameterType == typeof(string))
                {
                    arg = element.GetAttribute(parameter.Name ?? "");
                    // arg = (string)arg == "" ? Type.Missing : arg;
                }

                args[i] = arg;
            }
            return args;
        }

        private static ConstructorInfo[] GetConstructor(string componentName, Type componentType)
        {
            ConstructorInfo[] constructors = componentType.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new Exception("Unknown component does not have any constructors: " + componentName);
            }
            return constructors;
        }

        private Type GetTypeByName(string typeName)
        {
            Type type = _uielementRegister.GetBuilder(typeName);
            return type;
        }

        private static Color GetBackGroundColor(XmlElement element)
        {
            Enum.TryParse(element.Attributes.GetNamedItem("backColor")?.Value
                ?? "Default", true, out Color backgroundColor);
            return backgroundColor;
        }

        private static Color GetForeGroundColor(XmlElement element)
        {
            string? color = element.Attributes.GetNamedItem("frontColor")?.Value;
            Enum.TryParse(color
                ?? "Default", true, out Color backgroundColor);
            return backgroundColor;
        }

        private static IBorder GetBorder(XmlElement element)
        {
            IBorder border;
            string borderOption = element.Attributes.GetNamedItem("borderOption")?.Value ?? "default";
            int thickness;
            int.TryParse(element.Attributes.GetNamedItem("thickness")?.Value ?? "1", out thickness);

            switch (borderOption)
            {
                case "default":
                    border = new NoBorder();
                    break;
                case "simple":
                    border = new DetailedBorder(thickness, BorderOption.Simple);
                    break;
                case "heavy":
                    border = new DetailedBorder(thickness, BorderOption.Heavy);
                    break;
                default:
                    border = new DetailedBorder(thickness, BorderOption.GetBorderCharsFromFile(borderOption));
                    break;
            }
            return border;
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
                try
                {
                    var attributeName = attribute.Name;
                    var attributeValue = attribute.InnerText;
                    var method = _uielementRegister.GetMethod(builder.GetType(), attributeName);
                    method(builder, attributeValue);
                }
                catch (Exception e)
                {
                    _logger.Log();
                }
            }
            return builder.Build();
        }
    }
}

