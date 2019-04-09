using Script.StateMachineUtil;
using Script.Player.StateInput;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Player.States
{
    public class BasePlayerState : MonoBehaviour, IState
    {
        [SerializeField] private UnityEvent OnEnter;
        [SerializeField] private UnityEvent OnExit;

        protected Player player;
        protected StateMachine sm;
        protected Rigidbody2D rb;
        protected IInputHandler input;

        protected void Awake() {
            var obj = GameObject.FindGameObjectWithTag("Player");
            player = obj.GetComponent<Player>();
            sm = obj.GetComponentInChildren<StateMachine>();
            rb = obj.GetComponent<Rigidbody2D>();
            input = GetComponent<IInputHandler>();
            enabled = false;
        }

        public virtual string Name { get; } = "Base";

        public virtual bool Enter()
        {
            enabled = true;
            OnEnter.Invoke();
            return true;
        }

        public virtual void Exit()
        {
            OnExit.Invoke();
            enabled = false;
        }
    }  
}
