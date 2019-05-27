using UnityEngine;

namespace Script.Effects
{
    public class MoveEffect : MonoBehaviour, IEffect
    {
        private ParticleSystem particle;
        private Animator animator;

        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }
        
        public void Play()
        {
            animator.SetFloat("Speed", 1f);
            particle.Play();
        }

        public void Stop()
        {
            particle.Stop();
        }
    }
}