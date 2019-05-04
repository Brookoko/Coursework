using UnityEngine;
using UnityEngine.Events;

namespace Script.Effects
{
    public class FadingEffect : MonoBehaviour, IEffect
    {
        public UnityEvent OnFadeOutEnd;
        [SerializeField] private UnityEvent OnFadeOutIn;
        
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Play()
        {
            Input.Disable();
            anim.SetTrigger("Fade");
        }

        public void OnFadeInEnd()
        {
            OnFadeOutIn.Invoke();
        }

        public void Stop()
        {
            anim.ResetTrigger("Fade");
            OnFadeOutEnd.Invoke();
        }
    }
}