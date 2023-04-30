using System.Text.Json;

namespace Gift.SignalHandler.KeyInput
{
    //GPT stuff. No tests!! Don’t touch before tests are there

    class KeyMap
    {
        public KeyMap()
        {
            Map = new Dictionary<string, string>();
        }
        public Dictionary<string, string> Map { get; set; }
    }
    public class KeyMapper : IKeyMapper
    {

        public IList<IKeyMapping> GetMapping()
        {
            // Load the JSON file
            string json = File.ReadAllText("keymap.json");

            // Deserialize the JSON into a KeyMap object
            KeyMap keyMap = JsonSerializer.Deserialize<KeyMap>(json)?? new KeyMap();

            // Convert the key strings to ConsoleKey and ConsoleModifiers
            List<IKeyMapping> map = new List<IKeyMapping>();
            foreach (KeyValuePair<string, string> pair in keyMap.Map)
            {
                string[] keys = pair.Key.Split('+');
                ConsoleKey key = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), keys[keys.Length - 1], true);
                ConsoleModifiers modifiers = 0;
                for (int i = 0; i < keys.Length - 1; i++)
                {
                    modifiers |= (ConsoleModifiers)Enum.Parse(typeof(ConsoleModifiers), keys[i], true);
                }
                map.Add(new KeyMapping((key, modifiers), pair.Value));
            }
            return map;
        }
    }
}