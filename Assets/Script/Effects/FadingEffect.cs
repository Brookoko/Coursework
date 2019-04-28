using UnityEngine;
using UnityEngine.Events;
using Input = Script.Player.StateInput.Input;

namespace Script.Effects
{
    public class FadingEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private UnityEvent OnFadeOutEnd;
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