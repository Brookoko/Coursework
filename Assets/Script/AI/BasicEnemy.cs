using System.Linq;
using Script.AI.Reaction;
using Script.MoveControllers;
using UnityEngine;

namespace Script.AI
{
    [RequireComponent(typeof(IEntityReaction), typeof(IMoveController))]
    public class BasicEnemy : MonoBehaviour , IEnemy
    {
        private IEntityReaction behaviourOnEntity;
        private IMoveController controller;

        private void Start()
        {
            if (!Entity) Entity = GameObject.FindWithTag("Player").transform;
            controller = GetComponent<IMoveController>();
            behaviourOnEntity = GetComponents<IEntityReaction>()
                .FirstOrDefault(react => !react.Equals(this));
            behaviourOnEntity.Entity = Entity;
        }

        public Transform Entity { get; set; }
        
        public virtual bool IsEntityVisible() => behaviourOnEntity.IsEntityVisible();

        public virtual void Reaction() => behaviourOnEntity.Reaction();

        public virtual void Move(float move) => controller.Move(move);

        public virtual bool IsHitWall() => false;

        public virtual bool IsOnGround() => false;

        public virtual void Toggle() { }

        public virtual bool IsFrozen() => false;
    }
}