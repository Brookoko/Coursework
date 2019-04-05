using UnityEngine;


namespace Script.AI.Ant
{
    public class Idle : StateMachineBehaviour
    {
        public float timeToWait;
        
        private float timer;
        private Ant ant;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ant = animator.GetComponent<Ant>();
            timer = Random.Range(timeToWait - 1f, timeToWait + 1f);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ant.Move(0);
            if (timer < 0)
                animator.SetBool("Movement", true);
            else
                timer -= Time.deltaTime;

            if (ant.IsEntityVisible())
                animator.SetBool("Rage", true);
        }
    }
}
