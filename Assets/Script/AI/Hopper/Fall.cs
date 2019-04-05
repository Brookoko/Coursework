using UnityEngine;

namespace Script.AI.Hopper
{
    public class Fall : StateMachineBehaviour
    {
        private Rigidbody2D rb;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            rb = animator.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, -30f));
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (rb.velocity.y >= -0.01)
                animator.SetBool("Fall", false);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            rb.velocity = Vector2.zero;
        }
    }
}