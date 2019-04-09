using Script.StateMachineUtil;
using UnityEngine;

namespace Script.AI
{
    public class BaseEntityState : MonoBehaviour, IState
    {
        protected IEnemy entity;
        protected StateMachine sm;
        protected Animator anim;
        
        private void Awake()
        {
            Transform enemy = transform.parent.parent;
            entity = enemy.GetComponent<IEnemy>();
            sm = enemy.GetComponentInChildren<StateMachine>();
            anim = enemy.GetComponent<Animator>();
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