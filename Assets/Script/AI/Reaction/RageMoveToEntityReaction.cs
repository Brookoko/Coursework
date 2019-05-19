using System;
using UnityEngine;

namespace Script.AI.Reaction
{
    [Serializable]
    public class RageMoveToEntityReaction : MonoBehaviour, IEntityReaction
    {
        [SerializeField] private float distanceOfView = 10;
        [SerializeField] private float fieldOfView = 10;
        [SerializeField] private float rageSpeedUp = 3;
        
        private IEnemy enemy;
        private int direction;
        private Transform tran;
        
        private void Awake()
        {
            tran = transform.CompareTag("Enemy") ? transform : transform.parent;
            enemy = tran.GetComponent<IEnemy>();
        }

        public Transform Entity { get; set; }
        
        public bool IsEntityVisible()
        {
            var pos = Entity.position - tran.position;
            var angle = Vector2.Angle(Vector2.right * tran.localScale.x, pos);
            var visible = pos.sqrMagnitude < distanceOfView * distanceOfView && Mathf.Abs(angle) < fieldOfView;

            if (visible && direction == 0) direction = pos.x > 0 ? 1 : -1;
            else if (!visible && direction != 0) direction = 0;
            
            return visible;
        }

        public void Reaction()
        {
            if (direction == 0) direction = (int) tran.localScale.x;
            enemy.Move(rageSpeedUp * Time.deltaTime * direction);
        }
    }
}