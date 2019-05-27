using System;
using System.Timers;
using UnityEngine;

namespace Script.AI
{
    [Serializable]
    public class StayAtDistanceReaction : MonoBehaviour, IEntityReaction
    {
        [SerializeField] private float distanceOfView;
        [SerializeField] private float stopDistance;
        [SerializeField] private float retreatDistance;
        [SerializeField] private float speed;

        private float dist;
        private Rigidbody2D rb;
        private Transform tran;
        
        private void Awake()
        {
            if (transform.CompareTag("Enemy"))
            {
                tran = transform;
                rb = GetComponent<Rigidbody2D>();
            }
            else
            {
                tran = transform.parent;
                rb = tran.GetComponent<Rigidbody2D>();
            }
        }

        public bool IsEntityVisible(Transform entity)
        {
            return DistanceToPlayer(entity) < distanceOfView * distanceOfView;
        }
        
        private float DistanceToPlayer(Transform entity)
        {
            return dist = (tran.position - entity.position).sqrMagnitude;
        }

        public void Reaction(Transform entity)
        {
            if (dist > stopDistance * stopDistance)
                rb.MovePosition(Vector2.MoveTowards(tran.position, entity.position, speed * Time.deltaTime));
            else if (dist < retreatDistance * retreatDistance)
                rb.MovePosition(Vector2.MoveTowards(tran.position, entity.position, -speed * Time.deltaTime));
        }
    }
}