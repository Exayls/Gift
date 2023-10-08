using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gift.src.Services.SignalHandler.Key
{
    //GPT stuff. No tests!! Don’t touch before tests are there

    class KeyMap
    {
        public KeyMap()
        {
            Map = new List<(string, string)>();
        }
        public KeyMap(List<(string, string)> values)
        {
            Map = values;
        }
        public List<(string, string)> Map { get; set; }
    }
    public class KeyMapper : IKeyMapper
    {

        public IList<IKeyMapping> GetMapping()
        {
            // Load the JSON file
            string json = File.ReadAllText("ressources/keyconfig/keymap.json");

            // Deserialize the JSON into a KeyMap object
            Dictionary<string, string>? keyMap = JsonSerializer.Deserialize<Dictionary<string, string>>(json);


            // Convert the key strings to ConsoleKey and ConsoleModifiers
            List<IKeyMapping> map = new List<IKeyMapping>();
            if (keyMap == null)
            {
                return map;
            }
            foreach (KeyValuePair<string, string> pair in keyMap)
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
