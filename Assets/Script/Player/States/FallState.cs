using UnityEngine;

namespace Script.Player.States
{
    public class FallState : BasePlayerState
    {
        [SerializeField] private bool airControl;

        private float movement;
        
        public override string Name { get; } = "Fall";

        public override bool Enter()
        {
            animator.SetBool("isFalling", true);
            return base.Enter();
        }

        private void Update()
        {
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(0, rb.velocity.y), 0.6f);
            if (IsOnGround())
                sm.ChangeState("Idle");
            if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }

        private void FixedUpdate()
        {
            if (airControl)
                controller.Move(movement * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            animator.SetBool("isFalling", false);
            base.Exit();
        }
    }
}