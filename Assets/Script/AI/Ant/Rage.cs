using UnityEngine;

namespace Script.AI.Ant
{
    public class Rage : StateMachineBehaviour
    {
        public float rageTime;
        
        private float timer;
        private Ant ant;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("Movement", false);
            ant = animator.GetComponent<Ant>();
            timer = rageTime;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (ant.IsEntityVisible())
                ant.Reaction();
            if (!ant.IsEntityVisible() && timer < 0 || ant.IsHitWall())
                animator.SetBool("Rage", false);
            else
                timer -= Time.deltaTime;
        }
    }
}
