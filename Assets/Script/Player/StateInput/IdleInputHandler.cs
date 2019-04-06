using Script.StateMachineUtil;
using UnityEngine;

namespace Script.Player.StateInput
{
    public class IdleInputHandler : BaseInputHandler
    {
        public override void Handle()
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01)
                sm.ChangeState("Move");
            else if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Crouch"))
                sm.ChangeState("Crouch");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
    }
}