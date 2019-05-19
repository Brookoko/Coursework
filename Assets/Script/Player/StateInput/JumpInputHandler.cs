using UnityEngine;

namespace Script.Player.StateInput
{
    public class JumpInputHandler : BaseInputHandler
    {
        [SerializeField] private int jumpNumber = 1;
        [SerializeField] private float jumpTimeDelay = 0.1f;
        
        private int currentJumpNumber;
        private Rigidbody2D rb;
        private Player player;
        private Vector3 vel = Vector3.zero;
        private float timer;

        private void Start()
        {
            var player = GameObject.FindWithTag("Player");
            rb = player.GetComponent<Rigidbody2D>();
            this.player = player.GetComponent<Player>();
            currentJumpNumber = jumpNumber;
            timer = jumpTimeDelay;
        }

        public override bool ValidateInput()
        {
            if (!player.IsOnGround() && currentJumpNumber == jumpNumber && timer < 0) currentJumpNumber--;
            return currentJumpNumber-- > 0;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
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

        public void SetTimer()
        {
            timer = jumpTimeDelay;
        }
    }
}