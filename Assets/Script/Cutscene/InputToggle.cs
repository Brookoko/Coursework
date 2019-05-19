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
            enable = !enable;
        }

        public void Disable()
        {
            Input.Disable();
        }

        public void Enable()
        {
            Input.Enable();
        }
    }
}