using UnityEngine;

namespace Script.AI.Hopper
{
    public class FallState : BaseEntityState
    {
        [SerializeField] private Vector2 pushDownForce = new Vector2(0, -30);
        
        public override string Name { get; } = "Fall";

        public override bool Enter()
        {
            anim.SetBool("Fall", true);
            rb.AddForce(pushDownForce);
            return base.Enter();
        }

        private void Update()
        {
            if (rb.velocity.y >= -0.01) sm.ChangeState("Idle");
        }

        public override void Exit()
        {
            anim.SetBool("Fall", false);
            rb.velocity = Vector2.zero;
            base.Exit();
        }
    }
}