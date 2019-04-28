using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Menu
{
    public class PopUpImageDisplay : MonoBehaviour
    {
        [SerializeField] private PopUpImage[] dialogue;
        [SerializeField] private Image image;
        [SerializeField] private UnityEvent OnEnd;
        
        private Skippable skip;
        private PopUpImage current;
        private int index = 1;

        private void Start()
        {
            current = dialogue[0];
            skip = GetComponent<Skippable>();
        }

        public void Display()
        {
            SetImage();
            if (current.displayMode == 0) StartCoroutine(DisplayFading());
        }

        private void SetImage()
        {
            image.sprite = current.image;
            SetAlpha(0);
        }

        private IEnumerator DisplayFading()
        {
            SetAlpha(0);
            while (image.color.a < 1)
            {
                SetAlpha(image.color.a  + current.displaySpeed);
                yield return null;
            }
            skip.SetTime(current.timeOnScreen);
        }

        private void SetAlpha(float alpha)
        {
            Color c = image.color;
            c.a = alpha;
            image.color = c;
        }
        
        public void Fade()
        {
            skip.SetTime(float.PositiveInfinity);
            StopAllCoroutines();
            if (current.fadeMode == 0) StartCoroutine(Fading());
        }

        private IEnumerator Fading()
        {
            while (image.color.a > 0)
            {
                SetAlpha(image.color.a - current.fadeSpeed);
                yield return null;
            }
            current = index < dialogue.Length ? dialogue[index++] : null;
            if (current) Display();
        }
    }
}