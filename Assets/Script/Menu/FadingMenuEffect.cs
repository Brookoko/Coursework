using System.Collections;
using System.Collections.Generic;
using Script.Effects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script.Menu
{
    public class FadingMenuEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private float speed;
        [SerializeField] private UnityEvent OnEnd;
        
        private List<Image> images = new List<Image>();
        private float time;
        
        private void Awake()
        {
            AddImage(transform);
            time = (float) 60 / 255 * Time.deltaTime / 2;
            Debug.Log(images.Count);
            Debug.Log(time);
        }

        private void AddImage(Transform entity)
        {
            Image image = entity.GetComponent<Image>();
            if (image == null)
            {
                foreach (Transform child in entity)
                {
                    AddImage(child);
                }
            }
            else
            {
                images.Add(image);
            }
        }

        public void Play()
        {
            Debug.Log("Hey");
            StartCoroutine(Fading(true));
        }

        private IEnumerator Fading(bool fade)
        {
            for (int i = 0; i < 255; i++)
            {
                foreach (var image in images)
                {
                    Color c = image.color;
                    c.a = 0;
                    image.color = c;
                }
                yield return new WaitForSeconds(time);
            }
            if (fade) OnEnd.Invoke();
        }
        
        public void Stop()
        {
            StartCoroutine(Fading(false));
        }
    }
}