using UnityEngine;

namespace Script.Player.StateInput
{
    public class DashInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] private int dashNumber = 1;
        private static int currentDashNumber;

        public bool ValidateInput()
        {
            return currentDashNumber-- > 0;
        }

        public void Handle() {}
        
        public void ResetDash()
        {
            currentDashNumber = dashNumber;
        }

    }
}