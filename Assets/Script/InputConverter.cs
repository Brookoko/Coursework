using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script
{
    public class InputConverter
    {
        private static Dictionary<string, string> convert = new Dictionary<string, string>
        {
            {"RightShift", "right shift"},
            {"LeftShift", "left shift"},
            {"RightControl", "right ctrl"},
            {"LeftControl", "left ctrl"},
            {"RightAlt", "right alt"},
            {"LeftAlt", "left alt"},
            {"Space", "space"},
            {"Q", "q"},
            {"E", "e"},
            {"R", "r"},
            {"T", "t"},
            {"Y", "y"},
            {"U", "u"},
            {"I", "i"},
            {"O", "o"},
            {"P", "p"},
            {"F", "f"},
            {"G", "g"},
            {"H", "h"},
            {"J", "j"},
            {"K", "k"},
            {"L", "l"},
            {"Z", "z"},
            {"X", "x"},
            {"C", "c"},
            {"V", "v"},
            {"B", "b"},
            {"N", "n"},
            {"M", "m"}
        };

        public string GetValue(string value)
        {
            return convert.ContainsKey(value) ? convert[value] : convert.ContainsValue(value) ? value : string.Empty;
        }
        
        public int ConvertToInt(string code)
        {
            string s = convert.FirstOrDefault(x => x.Value.Equals(code)).Key;
            if (Enum.TryParse<KeyCode>(s, out var c)) return (int) c;
            return -1;
        }

        public string ConvertToCode(int value)
        {
            return ConvertToCode(((KeyCode) value).ToString());
        }

        public string ConvertToCode(string value)
        {
            return convert.ContainsKey(value) ? convert[value] : "";
        }

        public string ConvertToString(string value)
        {
            return convert.FirstOrDefault(x => x.Value.Equals(value)).Key;
        }
    }
}