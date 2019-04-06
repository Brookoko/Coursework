using Script.Player.StateInput;
using UnityEngine;
using Input = Script.Player.StateInput.Input;

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
            if (IsOnGround()) sm.ChangeState("Idle");
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(0, rb.velocity.y), 0.6f);
            input.Handle();
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