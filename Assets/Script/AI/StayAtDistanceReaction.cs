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
        [Space]

        private float dist;
        
        public bool IsEntityVisible(Transform entity)
        {
            return DistanceToPlayer(entity) < distanceOfView * distanceOfView;
        }
        
        private float DistanceToPlayer(Transform entity)
        {
            return dist = (transform.position - entity.position).sqrMagnitude;
        }

        public void Reaction(Transform entity)
        {
            if (dist > stopDistance * stopDistance)
                transform.position = Vector2.MoveTowards(transform.position, entity.position, speed * Time.deltaTime);
            else if (dist < retreatDistance * retreatDistance)
                transform.position = Vector2.MoveTowards(transform.position, entity.position, -speed * Time.deltaTime);
        }
    }
}