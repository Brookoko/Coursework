using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class FallInputHandler : MonoBehaviour, IInputHandler
    {
        private StateMachine sm;

        private void Awake()
        {
            sm = transform.parent.GetComponent<StateMachine>();
        }

        public bool ValidateInput()
        {
            return true;
        }

        public void Handle()
        {
            if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
    }
}