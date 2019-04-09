using UnityEngine;

namespace Script.Player.StateInput
{
    public class DashInputHandler : BaseInputHandler
    {
        [SerializeField] private int dashNumber = 1;
        [SerializeField] private float timeBtwDash = 3f;
        
        private int currentDashNumber;
        private Player player;
        private float timer;

        private void Start()
        {
            currentDashNumber = dashNumber;
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        public override bool ValidateInput()
        {
            var valid = currentDashNumber-- > 0 && timer < 0;
            if (valid) timer = timeBtwDash;
            return valid;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0) ResetDash();
        }

        public override void Handle()
        {
            if (player.IsOnGround()) ResetDash();
        }
        
        public void ResetDash()
        {
            currentDashNumber = dashNumber;
        }

    }
}