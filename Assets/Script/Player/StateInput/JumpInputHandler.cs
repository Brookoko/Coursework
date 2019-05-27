using UnityEngine;

namespace Script.Player.StateInput
{
    public class JumpInputHandler : BaseInputHandler
    {
        [SerializeField] private int jumpNumber = 1;

        private int currentJumpNumber;
        private Rigidbody2D rb;
        private Player player;
        private Vector3 vel = Vector3.zero;

        private void Start()
        {
            var player = GameObject.FindWithTag("Player");
            rb = player.GetComponent<Rigidbody2D>();
            this.player = player.GetComponent<Player>();
            currentJumpNumber = jumpNumber;
        }

        public override bool ValidateInput()
        {
            if (Mathf.Abs(rb.velocity.y) > 0.01f && currentJumpNumber == jumpNumber) currentJumpNumber--;
            return currentJumpNumber-- > 0;
        }
        
        public override void Handle()
        {
            if (Input.GetButtonDown("Jump") && currentJumpNumber > 0)
                sm.ChangeState("Jump");

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
                rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector2.zero, ref vel, .03f);
            
            if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");

            if (player.IsOnGround() && rb.velocity.y <= 0)
                sm.ChangeState("Idle");
        }
        
        public void ResetJumps()
        {
            currentJumpNumber = jumpNumber;
        }

        public void SetJumpNumber(int jumps)
        {
            jumpNumber = jumps;
        }
    }
}