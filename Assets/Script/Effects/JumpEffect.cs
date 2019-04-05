using Script.Player.States;
using UnityEngine;

namespace Script.Effects
{
    public class JumpEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private BasePlayerState state;
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

        public void OnLandEffect()
        {
            var vel = particle.inheritVelocity;
            vel.enabled = false;
            var sh = particle.shape;
            sh.shapeType = ParticleSystemShapeType.Circle;
            sh.radius = 0.8f;
            sh.scale = new Vector3(0.8f, 0.5f, 1);
            particle.Emit(70);
            sh.shapeType = ParticleSystemShapeType.SingleSidedEdge;
            sh.radius = 0.2f;
            vel.enabled = true;
        }
    }
}