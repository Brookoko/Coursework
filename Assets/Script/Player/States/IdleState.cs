using UnityEngine;

namespace Script.Player.States
{
    public class IdleState : BasePlayerState
    {
        public override string Name { get; } = "Idle";

        public override bool Enter()
        {
            animator.SetFloat("Speed", 0f);
            return base.Enter();
        }

        private void Update()
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(0, rb.velocity.y), 0.6f);
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01)
                sm.ChangeState("Move");
            else if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Crouch"))
                sm.ChangeState("Crouch");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
    }
}