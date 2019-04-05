using UnityEngine;
using UnityEngine.Animations;

namespace Script.AI.Hopper
{
    public class Jump : StateMachineBehaviour
    {
        private Rigidbody2D rb;
        private Hopper hopper;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            var direction = Random.Range(0, 2) == 0 ? 1 : -1;
            hopper = animator.GetComponent<Hopper>();
            hopper.Move(direction * Time.deltaTime);
            rb = animator.GetComponent<Rigidbody2D>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (rb.velocity.y < 0.01)
                animator.SetBool("Fall", true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}