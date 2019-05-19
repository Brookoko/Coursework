using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Script.HitBox
{
    public class BaseAlive : MonoBehaviour, IAlive
    {
        [SerializeField] private int health = 5;
        [SerializeField] private float invulnerableTime = 0.5f;
        public UnityEvent OnDamage;
        public UnityEvent OnHeal;
        [SerializeField] private UnityEvent OnDeath;
        
        private float timer;
        private Collider2D col;
        private int current;
        
        private void Awake()
        {
            col = GetComponent<Collider2D>();
            current = health;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }
        
        public void GetDamage(int damage)
        {
            current -= damage;
            if (current > health) current = health;
            if (damage == 0) return;
            if (damage < 0)
            {
                OnHeal.Invoke();
                return;
            }
            OnDamage.Invoke();
            StartCoroutine(Invulnerability(invulnerableTime));
        }

        public int Health() => current;
        
        public bool IsAlive() => current > 0;

        public void Death() => OnDeath.Invoke();

        public bool IsVulnerable() => timer < 0;

        public void SetInvulnerability(float time) => StartCoroutine(Invulnerability(time));

        private IEnumerator Invulnerability(float time)
        {
            timer = time;
            col.enabled = false;
            yield return new WaitForSeconds(time);
            col.enabled = true;
        }
    }
}