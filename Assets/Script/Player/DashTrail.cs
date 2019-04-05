using UnityEngine;

namespace Script.Player
{
    public class DashTrail : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 0.5f;

        private SpriteRenderer render;
        private Color color;
        private float initialAlpha;
        private float timer;
    
        private void Start()
        {
            render = transform.GetComponent<SpriteRenderer>();
            color = render.color;
            initialAlpha = color.a;
            timer = lifeTime;
        }

        void Update()
        {
            if (timer <= 0)
                Destroy(gameObject);
            else 
                timer -= Time.deltaTime;

            color.a = timer / lifeTime * initialAlpha;
            render.color = color;
        }
    }
}