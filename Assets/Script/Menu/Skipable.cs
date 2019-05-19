using UnityEngine;
using UnityEngine.Events;

namespace Script.Menu
{
    public class Skipable : MonoBehaviour
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
            if (!skipButton.Equals("") && GetData()) OnSkipEvent.Invoke();
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

        private bool GetData()
        {
            if (string.IsNullOrEmpty(skipButton)) return false;
            if (!skipButton.Contains("&")) return Input.GetButtonDown(skipButton);
            bool res = true;
            int lastSpecialSymbol = -1;
            for (int i = 0; i < skipButton.Length; i++)
            {
                if (skipButton[i].Equals('&'))
                {
                    string data = skipButton.Substring(lastSpecialSymbol + 1, 
                        i - lastSpecialSymbol - 1);
                    res = res && GetInputData(data);
                    lastSpecialSymbol = i;
                }
            }

            res = res && GetInputData(skipButton.Substring(lastSpecialSymbol + 1,
                      skipButton.Length - lastSpecialSymbol - 1));
            return res;
        }

        private bool GetInputData(string data)
        {
            if (data.Contains("+") || data.Contains("-"))
                return GetAxisData(data);
            return Input.GetButtonDown(data);
        }
        
        private bool GetAxisData(string value)
        {
            string direction = value[value.Length - 1].ToString();
            string axis = value.Substring(0, value.Length - 1);
            float v = Input.GetAxisRaw(axis);
            if (direction.Equals("+") && v > 0) return true;
            if (direction.Equals("-") && v < 0) return true;
            return false;
        }
    }
}