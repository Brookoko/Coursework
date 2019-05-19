using System;
using System.Collections.Generic;
using System.Linq;
using Script.SaveLoad;
using UnityEngine;

namespace Script
{
    public static class Input
    {
        private static InputConverter convert = new InputConverter();
        
        static Input()
        {
            SaveLoadProgress.Load();
            Table table = SaveLoadProgress.LoadTable();
            if (table != null)
            {
                for (int i = 0; i < table.input.Length; i++)
                {
                    tableOfAvailability.Add(table.input[i], table.available[i]);
                }
            }
        }
        
        private static Dictionary<string, string> axis = new Dictionary<string, string>
        {
            {"Jump", "space"},
            {"Dash", "c"},
            {"Crouch", "left ctrl"},
            {"Heal", "z"}
        };
        
        public static Dictionary<string, bool> tableOfAvailability = new Dictionary<string, bool>();
        
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
            value = convert.GetValue(value);
            if (string.IsNullOrEmpty(value) || !axis.ContainsKey(axisName)) return;
            if (tableOfAvailability.ContainsKey(axis[axisName]))
            {
                if (tableOfAvailability.ContainsKey(value))
                    tableOfAvailability[value] = tableOfAvailability[axis[axisName]];
                else
                    tableOfAvailability.Add(value, tableOfAvailability[axis[axisName]]);
            }
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
    }
}