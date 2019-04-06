namespace Script.Player.StateInput
{
    public interface IInputHandler
    {
        bool ValidateInput();
        void Handle();
    }
}