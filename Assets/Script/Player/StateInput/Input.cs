using System.Collections.Generic;

namespace Script.Player.StateInput
{
    public static class Input
    {
        private static Dictionary<string, bool> tableOfAvailability = new Dictionary<string, bool>();
        
        private static bool enable = true;
        
        public static float GetAxisRaw(string axis)
        {
            if (!tableOfAvailability.ContainsKey(axis)) SetAvailability(axis, true);
            if (!enable || !tableOfAvailability[axis]) return 0;
            return UnityEngine.Input.GetAxisRaw(axis);
        }

        public static bool GetButton(string button)
        {
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && UnityEngine.Input.GetButton(button);
        }
        
        public static bool GetButtonDown(string button)
        {
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && UnityEngine.Input.GetButtonDown(button);
        }
        
        public static bool GetButtonUp(string button)
        {
            if (!tableOfAvailability.ContainsKey(button)) SetAvailability(button, true);
            return enable && tableOfAvailability[button] && UnityEngine.Input.GetButtonUp(button);
        }

        public static void Enable()
        {
            enable = true;
        }

        public static void Disable()
        {
            enable = false;
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