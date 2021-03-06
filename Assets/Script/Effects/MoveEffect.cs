using UnityEngine;

namespace Script.Effects
{
    public class MoveEffect : MonoBehaviour, IEffect
    {
        private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
        }
        
        public void Play()
        {
            particle.Play();
        }

        public void Stop()
        {
            particle.Stop();
        }
    }
}