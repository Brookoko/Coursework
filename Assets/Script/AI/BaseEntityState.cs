using Script.StateMachineUtil;
using UnityEngine;

namespace Script.AI
{
    public class BaseEntityState : MonoBehaviour, IState
    {
        protected Transform entity;
        protected IEnemy enemy;
        protected StateMachine sm;
        protected Animator anim;
        protected Rigidbody2D rb;
   
        private void Awake()
        {
            entity = transform.parent.parent;
            enemy = entity.GetComponent<IEnemy>();
            sm = entity.GetComponentInChildren<StateMachine>();
            anim = entity.GetComponent<Animator>();
            rb = entity.GetComponent<Rigidbody2D>();
            enabled = false;
        }

        public virtual string Name { get; } = "Base";

        public virtual bool Enter()
        {
            enabled = true;
            return true;
        }

        public virtual void Exit()
        {
            enabled = false;
        }
    }
}