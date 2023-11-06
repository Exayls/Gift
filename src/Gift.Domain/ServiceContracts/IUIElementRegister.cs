using System;
using Gift.Domain.Builders;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        void Register(string name, Type type);

        public void Register<TBuilder>(string name)
            where TBuilder : IUIElementBuilder;

        void Register<TBuilder>(string attributeName, Func<TBuilder, string, TBuilder> builderMethod)
            where TBuilder : IUIElementBuilder;

        void Register<TBuilder, T2>(string attributeName, Func<TBuilder, T2, TBuilder> BuilderMethod)
            where TBuilder : IUIElementBuilder;

        Type GetBuilder(string componentName);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod<Builder>(string attribute);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(Type builder, string attribute);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(string builderName, string attribute);
    }
}
