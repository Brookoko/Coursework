using UnityEngine;

namespace Script.AI.Hopper
{
    public class Idle : StateMachineBehaviour
    {
        [SerializeField] private float timeBtwJump;
        [SerializeField] private float timeReductionOnRage;
        
        private int colliderCount;
        private Hopper hopper;
        private float timer;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            hopper = animator.GetComponent<Hopper>();
            timer = timeBtwJump;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (timer <= 0 || hopper.IsEntityVisible())
                animator.SetBool("IsJumping", true);

            timer -= Time.deltaTime;
        }
    }
}