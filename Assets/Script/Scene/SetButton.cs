using UnityEngine;

namespace Script.Scene
{
    public class SetButton : MonoBehaviour
    {
        public void Enable(string button)
        {
            Input.SetAvailability(button, true);
        }
        
        public void Disable(string button)
        {
            Input.SetAvailability(button, false);
        }
    }
}