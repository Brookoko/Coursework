using System.Collections;
using Script.Scene;
using UnityEngine;

namespace Script.Effects
{
    public class DashEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private GameObject dashTrail;
        [SerializeField] private CameraShake shake;

        private Transform player;
        private ParticleSystem particle;
        private Animator animator;
        private TrailRenderer trail;
        private Vector3 pos;
        private Coroutine cor;
        
        private void Awake()
        {
            player = GameObject.FindWithTag("Player").transform;
            particle = GetComponent<ParticleSystem>();
            trail = GetComponent<TrailRenderer>();
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetBool("isDashing", true);
            particle.Play();
            trail.enabled = true;
            StartCoroutine(shake.Shake(0.4f, 2f, 0.4f));
            pos = player.position;
        }

        public void Stop()
        {
            animator.SetBool("isDashing", false);           
            trail.enabled = false;
            particle.Stop();
        }

        private IEnumerator Trail()
        {
            while (true)
            {
                if (Vector3.Distance(pos, transform.position) > 2f)
                {
                    pos = transform.position;
                    Instantiate(dashTrail, player.position, Quaternion.identity);
                }
                yield return null;
            }
        }
    }
}