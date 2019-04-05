using System;
using System.Xml.Linq;
using Script.MoveControllers;
using UnityEngine;

namespace Script.AI
{
    [Serializable]
    public class RageMoveToEntityReaction : MonoBehaviour, IEntityReaction
    {
        [SerializeField] private float distanceOfView = 10;
        [SerializeField] private float fieldOfView = 10;
        [SerializeField] private float rageSpeedUp = 3;
        
        private IEnemy enemy;
        private int direction;

        private void Awake()
        {
            enemy = GetComponent<IEnemy>();
        }

        public bool IsEntityVisible(Transform entity)
        {
            var pos = entity.position - transform.position;
            var angle = Vector2.Angle(transform.forward, pos);
            var visible = pos.sqrMagnitude < distanceOfView * distanceOfView && Mathf.Abs(angle) < fieldOfView;

            if (visible && direction == 0)
                direction = pos.x > 0 ? 1 : -1;
            else if (!visible && direction != 0)
                direction = 0;
            
            return visible;
        }

        public void Reaction(Transform entity)
        {
            int x = direction;
            if (Mathf.Abs(entity.position.x - transform.position.x) < 0.1)
                x = direction;                
            enemy.Move(rageSpeedUp * Time.deltaTime * x);
        }
    }
}