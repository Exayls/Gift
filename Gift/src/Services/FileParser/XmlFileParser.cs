﻿using Gift.Builders;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gift.src.Services.FileParser
{
    public class XmlFileParser : IXMLFileParser
    {
        private IUIElementRegister _uielementRegister;

        public XmlFileParser(IUIElementRegister elementRegister)
        {
            _uielementRegister = elementRegister;
        }
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
                AddChild(giftui, childNode);
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

        private IUIElement CreateUIElement(XmlElement element)
        {
            IUIElement component;

            //IBorder border = GetBorder(element);
            //Color foregroundColor = GetForeGroundColor(element);
            //Color backgroundColor = GetBackGroundColor(element);

            component = CreateUnknownComponent(element);
            //switch (element.Name)
            //{
            //    case "GiftUI":
            //        component = new GiftUI();
            //        break;
            //    case "Vstack":
            //        component = new VStackBuilder().WithBorder(border)
            //            .WithBackgroundColor(backgroundColor)
            //            .WithForegroundColor(foregroundColor)
            //            .Build();
            //        break;
            //    case "Hstack":
            //        component = new HStackBuilder().WithBorder(border)
            //            .WithBackgroundColor(backgroundColor)
            //            .WithForegroundColor(foregroundColor)
            //            .Build();
            //        break;
            //    case "Label":
            //        component = new LabelBuilder().WithBorder(border)
            //            .WithText(element.InnerText)
            //            .WithBackgroundColor(backgroundColor)
            //            .WithForegroundColor(foregroundColor)
            //            .Build();
            //        break;

            //    default:
            //        throw new NotSupportedException("Unsupported UI component: " + element.Name);
            //}
            return component;
        }

        private IUIElement CreateUnknownComponent(XmlElement element)
        {
            string componentName = element.Name;
            Type componentType = GetTypeByName(componentName);

            if (componentType == null)
            {
            }

            ConstructorInfo constructor = GetConstructor(componentName, componentType);

            IUIElement uiElement = ConstructElementViaConstructor(element, componentName, constructor);

            //SelectContainer(uiElement, element);
            //SelectElement(uiElement, element);
            return uiElement;
        }

        private void SelectContainer(IUIElement uiElement, XmlElement element)
        {
            if (uiElement is Container container)
            {
                if(element.GetAttribute("selectableContainer") == "true")
                {
                    container.IsInSelectedContainer = true;
                }
            }
        }

        private static IUIElement ConstructElementViaConstructor(XmlElement element, string componentName, ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                object arg = null;

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
                    arg = (string)arg == "" ? Type.Missing : arg;
                }

                args[i] = arg;
            }

            object componentInstance = constructor.Invoke(args);

            if (componentInstance is not IUIElement uiElement)
            {
                throw new Exception("Unknown component does not implement IUIElement: " + componentName);
            }

            return uiElement;
        }

        private static ConstructorInfo GetConstructor(string componentName, Type componentType)
        {
            ConstructorInfo[] constructors = componentType.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new Exception("Unknown component does not have any constructors: " + componentName);
            }

            ConstructorInfo constructor = constructors[0];
            return constructor;
        }

        private Type GetTypeByName(string typeName)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //var a = assembly.GetTypes();
            //Type? type = assembly.GetType(typeName, false, true);
            Type type = _uielementRegister.GetTypeByName(typeName);
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
