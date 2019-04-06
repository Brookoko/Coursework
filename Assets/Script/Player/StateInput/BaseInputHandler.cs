using Script.MoveControllers;
using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class BaseInputHandler : MonoBehaviour, IInputHandler
    {
        protected StateMachine sm;
        protected IMoveController controller;

        private void Awake()
        {
            sm = transform.parent.GetComponent<StateMachine>();
        }
        
        public virtual bool ValidateInput()
        {
            return true;
        }

        public virtual void Handle() {}
    }
}