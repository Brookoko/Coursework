using UnityEngine;
using UnityEngine.Events;

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

        public void SetButton(string btn)
        {
            skipButton = btn;
        }

        private bool GetData(string* data)
        {
            if (string.IsNullOrEmpty(skipButton)) return false;
            if (!skipButton.Contains("&") || !skipButton.Contains("|")) return Input.GetButtonDown(skipButton);
            int lastSpecialSymbol = -1;
            for (int i = 0; i < skipButton.Length; i++)
            {
                if (skipButton[i].Equals('&'))
                {
                    string value = skipButton.Substring(lastSpecialSymbol + 1, i - lastSpecialSymbol - 1);
                    
                }
            }
        }
    }
}