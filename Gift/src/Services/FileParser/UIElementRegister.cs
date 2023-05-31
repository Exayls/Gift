using Gift.UI.Element;

namespace Gift.src.Services.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private IDictionary<string, Type> _elements;

        public UIElementRegister()
        {
            _elements = new Dictionary<string, Type>();
        }

        public Type GetTypeByName(string typeName)
        {
            string key = typeName.ToLower();
            if (!_elements.ContainsKey(key))
            {
                throw new NullReferenceException();
            }
            return _elements[key];
        }

        public void Register(string name, Type type)
        {
            _elements.Add(name.ToLower(), type);
        }
    }
}