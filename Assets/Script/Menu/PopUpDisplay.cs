using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Script.Menu
{
    public class PopUpDisplay : MonoBehaviour
    {
        [SerializeField] private PopUp[] dialogue;
        [SerializeField] private TextMeshProUGUI textDisplay;
        [SerializeField] private UnityEvent OnEnd;
        
        private Skippable skip;
        private PopUp current;
        private int index = 1;

        private void Start()
        {
            current = dialogue[0];
            skip = GetComponent<Skippable>();
        }

        public void Display()
        {
            textDisplay.text = "";
            if (current.displayMode == 0) StartCoroutine(DisplayFading());
            else if (current.displayMode == 1) StartCoroutine(DisplayLetterByLetter());
        }

        private IEnumerator DisplayFading()
        {
            textDisplay.text = current.text;
            SetAlpha(0);
            while (textDisplay.color.a < 1)
            {
                SetAlpha(textDisplay.color.a  + current.displaySpeed);
                yield return null;
            }
            skip.SetTime(current.timeOnScreen);
        }

        private void SetAlpha(float alpha)
        {
            Color c = textDisplay.color;
            c.a = alpha;
            textDisplay.color = c;
        }
        
        private IEnumerator DisplayLetterByLetter()
        {
            int cur = 0;
            for (int i = 0; i < current.text.Length; i++)
            {
                if (cur < current.index.Length && current.index[cur] == i)
                {
                    current.displaySpeed = current.speed[cur++];
                }
                textDisplay.text += current.text[i];
                yield return new WaitForSeconds(current.displaySpeed);
            }
            skip.SetTime(current.timeOnScreen);
        }

        public void Fade()
        {
            skip.SetTime(float.PositiveInfinity);
            StopAllCoroutines();
            if (current.fadeMode == 0) StartCoroutine(Fading());
            else if (current.fadeMode == 1) StartCoroutine(FadeLetterByLetter());
        }

        private IEnumerator Fading()
        {
            while (textDisplay.color.a > 0)
            {
                SetAlpha(textDisplay.color.a - current.fadeSpeed);
                yield return null;
            }
            current = index < dialogue.Length ? dialogue[index++] : null;
            if (current) Display();
        }
        
        private IEnumerator FadeLetterByLetter()
        {
            while (textDisplay.text.Length > 0)
            {
                textDisplay.text = textDisplay.text.Remove(textDisplay.text.Length - 1);
                yield return new WaitForSeconds(current.fadeSpeed);
            }
            current = index < dialogue.Length ? dialogue[index++] : null;
            if (current) Display();
            else OnEnd.Invoke();
        }
    }
}