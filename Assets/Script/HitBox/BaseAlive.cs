using System.Collections;
using UnityEngine;

namespace Script.HitBox
{
    public class BaseAlive : MonoBehaviour, IAlive
    {
        [SerializeField] private float health = 5;
        [SerializeField] private float invulnerableTime = 0.5f;
        [SerializeField] private float toggleTime = 0.1f;
        [SerializeField] private GameObject deathEffect;
      
        private float timer;
        private SpriteRenderer render;
        private Color color;
        private Animator anim;
        
        private void Awake()
        {
            render = transform.parent.GetComponent<SpriteRenderer>();
            color = render.color;
            anim = transform.parent.GetComponent<Animator>();
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }
        
        public virtual void GetDamage(float damage)
        {
            health -= damage;
            timer = invulnerableTime;
            StartCoroutine(Blinking());
        }

        public virtual bool IsAlive()
        {
            return health > 0;
        }

        public virtual void OnDeath()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }

        public virtual bool IsVulnerable()
        {
            return !(timer > 0);
        }
        
        protected IEnumerator Blinking()
        {
            while (timer > 0)
            {
                ReverseAlpha();
                yield return new WaitForSeconds(toggleTime);
            }
            render.color = new Color(color.r, color.g, color.b, 1);
        }

        private void ReverseAlpha()
        {
            render.color = new Color(color.r, color.g, color.b, color.a < 1 ? 1 : 0.3f);
            color = render.color;
        }
    }
}