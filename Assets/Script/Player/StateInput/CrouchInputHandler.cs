using UnityEngine;

namespace Script.Player.StateInput
{
    public class CrouchInputHandler : BaseInputHandler
    {
        private Player player;
        
        private void Start()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        public override void Handle()
        {
            if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
            if (!(player.IsHitCeil() || Input.GetButton("Crouch"))) sm.ChangeState("Idle");
        }
    }
}