using UnityEngine;

namespace Script
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
    }
}