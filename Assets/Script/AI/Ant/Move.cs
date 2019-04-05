using UnityEngine;

namespace Script.AI.Ant
{
    public class Move : StateMachineBehaviour
    {
        public float moveDuration;
        
        private float timer;
        private float movement;
        private int colliderCount;
        private Ant ant;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ant = animator.GetComponent<Ant>();
            timer = Random.Range(moveDuration - 2f, moveDuration + 2f);
            movement = Random.Range(0, 2) == 0 ? -1 : 1;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (timer < 0)
                ChangeDirection(animator);
            else
                timer -= Time.deltaTime;

            if (ant.IsHitWall())
                ChangeDirection(animator);
            
            if (ant.IsEntityVisible())
                animator.SetBool("Rage", true);
            
            ant.Move(movement * Time.deltaTime);
        }

        private void ChangeDirection(Animator animator)
        {
            if (Random.Range(0, 5) == 0)
                animator.SetBool("Movement", false);
            movement = Random.Range(0, 2) == 0 ? -1 : 1;
            timer = Random.Range(moveDuration - 2f, moveDuration + 2f);
        }
    }   
}
