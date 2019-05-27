using Script.Player.States;
using UnityEngine;

namespace Script.Effects
{
    public class JumpEffect : MonoBehaviour, IEffect
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
            animator.SetBool("isJumping", true);
            particle.Play();
        }

        public void Stop()
        {
            animator.SetBool("isJumping", false);
            particle.Stop();
        }
    }
}