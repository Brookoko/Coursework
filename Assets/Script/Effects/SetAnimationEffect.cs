using UnityEngine;

namespace Script.Effects
{
    public class SetAnimationEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private string parameter;
        [SerializeField] private Parameter type;
        [SerializeField] private bool onBool;
        [SerializeField] private float onFloat;
        [SerializeField] private bool offBool;
        [SerializeField] private float offFloat;
        
        private Animator animator;

        private void Awake()
        {
            animator = transform.parent.parent.GetComponent<Animator>();
        }

        public void Play()
        {
            if (type == Parameter.Bool) animator.SetBool(parameter, onBool);
            else if (type == Parameter.Float) animator.SetFloat(parameter, onFloat);
            else if (type == Parameter.Trigger) animator.SetTrigger(parameter);
        }

        public void Stop()
        {
            if (type == Parameter.Bool) animator.SetBool(parameter, offBool);
            else if (type == Parameter.Float) animator.SetFloat(parameter, offFloat);
            else if (type == Parameter.Trigger) animator.ResetTrigger(parameter);
        }
    }

    public enum Parameter
    {
        Float,
        Bool,
        Trigger
    }
}