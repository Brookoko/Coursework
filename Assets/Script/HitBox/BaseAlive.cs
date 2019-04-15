using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Script.HitBox
{
    public class BaseAlive : MonoBehaviour, IAlive
    {
        [SerializeField] private float health = 5;
        [SerializeField] private float invulnerableTime = 0.5f;
        [SerializeField] private UnityEvent OnDamage;
        [SerializeField] private UnityEvent OnDeath;
        
        private float timer;
        private Collider2D col;
        
        private void Awake()
        {
            col = GetComponent<Collider2D>();
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }
        
        public void GetDamage(float damage)
        {
            if (damage <= 0) return;
            OnDamage.Invoke();
            health -= damage;
            StartCoroutine(Invulnerability(invulnerableTime));
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public void Death()
        {
            OnDeath.Invoke();
            Destroy(transform.parent.gameObject);
        }

        public bool IsVulnerable()
        {
            return timer < 0;
        }

        public void SetInvulnerability(float time)
        {
            StartCoroutine(Invulnerability(time));
        }

        private IEnumerator Invulnerability(float time)
        {
            timer = time;
            col.enabled = false;
            yield return new WaitForSeconds(time);
            col.enabled = true;
        }
    }
}