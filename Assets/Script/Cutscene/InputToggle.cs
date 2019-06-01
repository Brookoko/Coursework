using UnityEngine;

namespace Script.Cutscene
{
    public class InputToggle : MonoBehaviour
    {
        private bool enable = true;
    
        private void OnEnable()
        {
            if (enable) Input.Disable();
            else Input.Enable();
        }

        public void Disable()
        {
            Input.Disable();
            enable = true;
        }

        public void Enable()
        {
            Input.Enable();
            enable = false;
        }
    }
}