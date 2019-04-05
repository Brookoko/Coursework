using UnityEngine;

namespace Script.AI.Gator
{
    public class Move : StateMachineBehaviour
    {
        private Gator gator;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            gator = animator.GetComponent<Gator>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            gator.Move();

            if (gator.IsEntityVisible())
                gator.Reaction();
        }
    }
}
