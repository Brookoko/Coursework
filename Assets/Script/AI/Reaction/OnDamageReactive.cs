using System;
using UnityEngine;
using UnityEngine.Events;

namespace Script.AI.Reaction
{
    public class OnDamageReactive : MonoBehaviour, IEntityReaction
    {
        [SerializeField] private TransformEvent OnTrigger;
        
        private bool trigger;
        private float timer;
        private IEnemy enemy;
        private Transform tran;

        public Transform Entity { get; set; }
        
        public bool IsEntityVisible() => trigger;

        public void Reaction()
        {
            if (!enemy.IsOnGround() || enemy.IsHitWall())
                enemy.Move(-tran.localScale.x * Time.deltaTime);
            OnTrigger.Invoke(Entity);
        }

        private void Awake()
        {
            tran = transform.CompareTag("Enemy") ? transform : transform.parent;
            enemy = tran.GetComponent<IEnemy>();
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0) trigger = false;
        }

        public void SetTrigger(int direction)
        {
            trigger = true;
            timer = 0.1f;
            if (!enemy.IsOnGround() || enemy.IsHitWall()) return;
            enemy.Move(direction * Time.deltaTime);
        }
    }
    
    [Serializable]
    public class TransformEvent : UnityEvent<Transform> { }
}