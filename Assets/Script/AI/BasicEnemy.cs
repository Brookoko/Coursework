using Script.MoveControllers;
using UnityEngine;

namespace Script.AI
{
    [RequireComponent(typeof(IEntityReaction), typeof(MoveController))]
    public class BasicEnemy : MonoBehaviour , IEnemy
    {
        protected Transform player;
        private IEntityReaction behaviourOnEntity;
        private MoveController controller;

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            controller = GetComponent<MoveController>();
            behaviourOnEntity = GetComponent<IEntityReaction>();
        }

        public virtual bool IsEntityVisible()
        {
            return behaviourOnEntity.IsEntityVisible(player);
        }

        public virtual void Reaction()
        {
            behaviourOnEntity.Reaction(player);
        }

        public virtual void Move(float move)
        {
            controller.Move(move);
        }
        
        public virtual bool IsHitWall()
        {
            return false;
        }
    }
}