using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script
{
    public static class Input
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
        
        private static Dictionary<string, string> axis = new Dictionary<string, string>
        {
            {"Jump", "space"},
            {"Dash", "c"},
            {"Crouch", "left ctrl"}
        };
        
        private static Dictionary<string, bool> tableOfAvailability = new Dictionary<string, bool>();
        
        private static bool enable = true;
        
        public static float GetAxisRaw(string axes)
        {
            if (!tableOfAvailability.ContainsKey(axes)) SetAvailability(axes, true);
            if (!enable || !tableOfAvailability[axes]) return 0;
            return UnityEngine.Input.GetAxisRaw(axes);
        }

        public static bool GetButton(string button)
        {
            bool value;
            if (axis.ContainsKey(button))
            {
                button = axis[button];
                value = UnityEngine.Input.GetKey(button);
            }
            else
            {
                value = UnityEngine.Input.GetButton(button);
            }
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && value;
        }
        
        public static bool GetButtonDown(string button)
        {
            bool value;
            if (axis.ContainsKey(button))
            {
                button = axis[button];
                value = UnityEngine.Input.GetKeyDown(button);
            }
            else
            {
                value = UnityEngine.Input.GetButtonDown(button);
            }
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && value;
        }
        
        public static bool GetButtonUp(string button)
        {
            bool value;
            if (axis.ContainsKey(button))
            {
                button = axis[button];
                value = UnityEngine.Input.GetKeyUp(button);
            }
            else
            {
                value = UnityEngine.Input.GetButtonUp(button);
            }
            button = axis.ContainsKey(button) ? axis[button] : button;
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && value;
        }

        public static void Enable()
        {
            enable = true;
        }

        public static void Disable()
        {
            enable = false;
        }

        public static void SetButton(string axisName, string value)
        {
            value = convert.ContainsKey(value) ? convert[value] : convert.ContainsValue(value) ? value : string.Empty;
            if (string.IsNullOrEmpty(value) || !axis.ContainsKey(axisName)) return;
            axis[axisName] = value;
        }

        public static string GetValue(string axisName)
        {
            return axis.ContainsKey(axisName) ? axis[axisName] : "";
        }
        
        public static void SetAvailability(string input, bool available)
        {
            if (tableOfAvailability.ContainsKey(input))
                tableOfAvailability[input] = available;
            else
                tableOfAvailability.Add(input, available);
        }
        
        public static int ConvertToInt(string code)
        {
            string s = convert.FirstOrDefault(x => x.Value.Equals(code)).Key;
            if (Enum.TryParse<KeyCode>(s, out var c)) return (int) c;
            return -1;
        }

        public static string ConvertToCode(int value)
        {
            return ConvertToCode(((KeyCode) value).ToString());
        }

        public static string ConvertToCode(string value)
        {
            return convert.ContainsKey(value) ? convert[value] : "";
        }
    }
}