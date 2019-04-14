using UnityEngine;

namespace Script.Effects
{
    public class SetAnimationEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private string parameter;
        [SerializeField] private bool on;
        [SerializeField] private bool off;
        
        private Animator animator;

        private void Awake()
        {
            animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        }

        public void Play()
        {
            animator.SetBool(parameter, on);
        }

        public void Stop()
        {
            animator.SetBool(parameter, off);
        }
    }
}