using UnityEngine;

namespace Script.Scene
{
    public class SetButton : MonoBehaviour
    {
        public void Enable(string button)
        {
            string axis = Input.GetValue(button);
            button = string.IsNullOrEmpty(axis) ? button : axis; 
            if (!string.IsNullOrEmpty(button)) Input.SetAvailability(button, true);
        }
        
        public void Disable(string button)
        {
            string axis = Input.GetValue(button);
            button = string.IsNullOrEmpty(axis) ? button : axis; 
            if (!string.IsNullOrEmpty(button)) Input.SetAvailability(button, false);
        }
    }
}