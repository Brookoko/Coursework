namespace Script.Player.StateInput
{
    public class Input
    {
        private static bool enable = true;
        
        public static float GetAxisRaw(string axis)
        {
            if (!enable) return 0;
            return UnityEngine.Input.GetAxisRaw(axis);
        }

        public static bool GetButton(string button)
        {
            return enable && UnityEngine.Input.GetButton(button);
        }
        
        public static bool GetButtonDown(string button)
        {
            return enable && UnityEngine.Input.GetButtonDown(button);
        }
        
        public static bool GetButtonUp(string button)
        {
            return enable && UnityEngine.Input.GetButtonUp(button);
        }

        public static void Enable()
        {
            enable = true;
        }

        public static void Disable()
        {
            enable = false;
        }
    }
}