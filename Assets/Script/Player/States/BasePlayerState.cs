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
        [SerializeField] private UnityEvent onLandEvent;
        protected GameObject player;
        protected StateMachine sm;
        protected PlayerSMStats stats;
        protected Animator animator;
        protected MoveController controller;
        protected Rigidbody2D rb;
        protected IEffect effect;
        protected IInputHandler input;

        private Collider2D[] cols = new Collider2D[1];
        private bool wasOnGround;
        
        protected void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            sm = player.GetComponentInChildren<StateMachine>();
            stats = sm.GetComponent<PlayerSMStats>();
            controller = player.GetComponent<MovementController>();
            animator = player.GetComponent<Animator>();
            rb = player.GetComponent<Rigidbody2D>();
            effect = GetComponent<IEffect>();
            input = GetComponent<IInputHandler>();
            enabled = false;
        }

        public bool IsOnGround()
        {
            var col = Physics2D.OverlapCircleNonAlloc(stats.groundCheck.position, stats.radius, cols, stats.whatIsGround);
            if (col > 0 && !wasOnGround) onLandEvent.Invoke();
            return wasOnGround = col > 0;
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
