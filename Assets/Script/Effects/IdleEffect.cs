using UnityEngine;

namespace Script.Effects
{
    public class IdleEffect : MonoBehaviour, IEffect
    {
        private Animator animator;

        private void Awake()
        {
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetFloat("Speed", 0f);

        }

        public void Stop() {}
    }
}