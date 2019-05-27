using System;
using System.Collections;
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
        private Transform tran;
        
        private void Awake()
        {
            if (transform.CompareTag("Enemy"))
            {
                tran = transform;
                enemy = GetComponent<IEnemy>();
            }
            else
            {
                tran = transform.parent;
                enemy = tran.GetComponent<IEnemy>();
            }
        }

        public bool IsEntityVisible(Transform entity)
        {
            var pos = entity.position - tran.position;
            var angle = Vector2.Angle(Vector2.right * tran.localScale.x, pos);
            var visible = pos.sqrMagnitude < distanceOfView * distanceOfView && Mathf.Abs(angle) < fieldOfView;

            if (visible && direction == 0) direction = pos.x > 0 ? 1 : -1;
            else if (!visible && direction != 0) direction = 0;
            
            return visible;
        }

        public void Reaction(Transform entity)
        {
            enemy.Move(rageSpeedUp * Time.deltaTime * direction);
        }
    }
}