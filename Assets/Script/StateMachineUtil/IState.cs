namespace Script.StateMachineUtil
{
    public interface IState {
        bool Enter();
        void Exit();
        string Name { get; }
    }
}
