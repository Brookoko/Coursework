namespace Script.Player.StateInput
{
    public class FallInputHandler : BaseInputHandler
    {
        public override void Handle()
        {
            if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }
    }
}