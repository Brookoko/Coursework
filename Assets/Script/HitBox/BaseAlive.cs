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
        
        private void Update()
        {
            timer -= Time.deltaTime;
        }
        
        public void GetDamage(float damage)
        {
            OnDamage.Invoke();
            health -= damage;
            timer = invulnerableTime;
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
    }
}