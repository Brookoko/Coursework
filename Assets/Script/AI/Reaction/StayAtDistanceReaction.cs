using System;
using UnityEngine;

namespace Script.AI.Reaction
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

        public Transform Entity { get; set; }
        
        public bool IsEntityVisible()
        {
            return DistanceToPlayer(Entity) < distanceOfView * distanceOfView;
        }
        
        private float DistanceToPlayer(Transform entity)
        {
            return dist = (tran.position - entity.position).sqrMagnitude;
        }

        public void Reaction()
        {
            if (dist > stopDistance * stopDistance)
                rb.MovePosition(Vector2.MoveTowards(tran.position, Entity.position, speed * Time.deltaTime));
            else if (dist < retreatDistance * retreatDistance)
                rb.MovePosition(Vector2.MoveTowards(tran.position, Entity.position, -speed * Time.deltaTime));
        }
    }
}