using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class MoveInputHandler : MonoBehaviour, IInputHandler
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
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01)
                sm.ChangeState("Idle");
            else if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Crouch"))
                sm.ChangeState("Crouch");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
    }
}