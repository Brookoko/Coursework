using UnityEngine;

namespace Script.Effects
{
    public class CrouchEffect : MonoBehaviour, IEffect
    {
        private Animator animator;

        private void Awake()
        {
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetBool("isCrouching", true);
        }

        public void Stop()
        {
            animator.SetBool("isCrouching", false);
        }
    }
}