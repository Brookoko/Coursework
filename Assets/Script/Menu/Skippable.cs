using UnityEngine;
using UnityEngine.Events;
using Input = Script.Player.StateInput.Input;

namespace Script.Menu
{
    public class Skippable : MonoBehaviour
    {
        [SerializeField] private string skipButton;
        [SerializeField] private UnityEvent OnSkipEvent;
        [SerializeField] private float time = float.PositiveInfinity;

        private float timer;

        private void Start()
        {
            SetTime(time);
        }

        private void Update()
        {
            if (!skipButton.Equals("") && Input.GetButtonDown(skipButton)) OnSkipEvent.Invoke();
            if (timer < 0)
            {
                SetTime(time);
                OnSkipEvent.Invoke();
            }
            timer -= Time.deltaTime;
        }

        public void SetTime(float time)
        {
            timer = time;
        }
    }
}