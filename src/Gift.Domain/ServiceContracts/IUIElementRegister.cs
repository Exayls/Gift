using System;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        void Register(string name, Type type);

        public void Register<TBuilder>(string name)
            where TBuilder : IUIElementBuilder;

        void Register<TBuilder>(Type builderType, string attributeName, Func<TBuilder, string, TBuilder> builderMethod)
            where TBuilder : IUIElementBuilder;

        void Register<TBuilder, T2>(Type builderType, string attributeName, Func<TBuilder, T2, TBuilder> BuilderMethod)
            where TBuilder : IUIElementBuilder;

        Type GetBuilder(string componentName);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod<TBuilder>(string attribute);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(Type builder, string attribute);
        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(string builderName, string attribute);
    }
}
