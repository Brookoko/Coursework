using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class BaseInputHandler : MonoBehaviour, IInputHandler
    {
        protected StateMachine sm;

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