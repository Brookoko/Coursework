using Script.Effects;
using Script.StateMachineUtil;
using Script.MoveControllers;
using Script.Player.StateInput;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Player.States
{
    public class BasePlayerState : BaseState
    {
        protected Player player;
        protected StateMachine sm;
        protected Animator animator;
        protected Rigidbody2D rb;
        protected IEffect effect;
        protected IInputHandler input;

        protected void Awake() {
            var obj = GameObject.FindGameObjectWithTag("Player");
            player = obj.GetComponent<Player>();
            sm = obj.GetComponentInChildren<StateMachine>();
            animator = obj.GetComponent<Animator>();
            rb = obj.GetComponent<Rigidbody2D>();
            effect = GetComponent<IEffect>();
            input = GetComponent<IInputHandler>();
            enabled = false;
        }

        public override bool Enter()
        {
            enabled = true;
            return true;
        }

        public override void Exit()
        {
            enabled = false;
        }
    }  
}
