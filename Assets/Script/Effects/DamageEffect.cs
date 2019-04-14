using System.Collections;
using UnityEngine;

namespace Script.Effects
{
    public class DamageEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private float toggleTime = 0.15f;
        [SerializeField] private float blinkingTime = 0.5f;
        
        private SpriteRenderer render;
        private Color color;
        private float timer;
        
        private void Awake()
        {
            var entity = transform.parent;
            render = entity.GetComponent<SpriteRenderer>();
            color = render.color;
        }

        public void Play()
        {
            timer = blinkingTime;
            StartCoroutine(Blinking());
        }

        public void Stop()
        {
            render.color = new Color(color.r, color.g, color.b, 1);
        }

        private IEnumerator Blinking()
        {
            while (timer > 0)
            {
                ReverseAlpha();
                timer -= toggleTime;
                yield return new WaitForSeconds(toggleTime);
            }
            Stop();
        }

        private void ReverseAlpha()
        {
            render.color = new Color(color.r, color.g, color.b, color.a < 1 ? 1 : 0.3f);
            color = render.color;
        }
    }
}