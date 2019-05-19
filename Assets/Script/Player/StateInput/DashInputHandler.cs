using UnityEngine;

namespace Script.Player.StateInput
{
    public class DashInputHandler : BaseInputHandler
    {
        [SerializeField] private int dashNumber = 1;
        
        private int currentDashNumber;
        private Player player;

        private void Start()
        {
            currentDashNumber = dashNumber;
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        public override bool ValidateInput()
        {
            return currentDashNumber-- > 0;
        }

        public void ResetOnGround()
        {
            if (player.IsOnGround()) ResetDash();
        }
        
        public void ResetDash()
        {
            currentDashNumber = dashNumber;
        }

        public void SetDashNumber(int dash)
        {
            dashNumber = dash;
        }
    }
}