using UnityEngine;

namespace Script.AI.Hopper
{
    public class JumpState : BaseEntityState
    {
        public override string Name { get; } = "Jump";

        public override bool Enter()
        {
            int direction = Random.Range(0, 2) == 0 ? 1 : -1;
            enemy.Move(direction * Time.deltaTime);
            anim.SetBool("IsJumping", true);
            return base.Enter();
        }

        private void Update()
        {
            if (rb.velocity.y < 0.01) sm.ChangeState("Fall");
        }

        public override void Exit()
        {
            anim.SetBool("IsJumping", false);
            base.Exit();
        }
    }
}