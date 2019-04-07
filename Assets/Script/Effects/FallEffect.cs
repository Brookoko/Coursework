using UnityEngine;

namespace Script.Effects
{
    public class FallEffect : MonoBehaviour, IEffect
    {
        private Animator animator;

        private void Awake()
        {
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetBool("isFalling", true);
        }

        public void Stop()
        {
            animator.SetBool("isFalling", false);
        }
    }
}