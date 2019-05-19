using UnityEngine;

namespace Script.Player.StateInput
{
    public class IdleInputHandler : BaseInputHandler
    {
        [SerializeField] private float delay = 0.2f;
        
        private float timer;
        private Player player;

        private void Start()
        {
            timer = delay;
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        public override void Handle()
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01)
                sm.ChangeState("Move");
            else if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Crouch"))
                sm.ChangeState("Crouch");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
            
            if (player.IsOnGround()) timer = delay;
            if (timer < 0 && !player.IsOnGround()) sm.ChangeState("Fall");
            
            timer -= Time.deltaTime;
        }
    }
}