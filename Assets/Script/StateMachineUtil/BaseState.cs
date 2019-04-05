using UnityEngine;

namespace Script.StateMachineUtil
{
    public class BaseState : MonoBehaviour, IState
    {
        public virtual bool Enter()
        {
            return true;
        }

        public virtual void Exit() {}

        public virtual string Name { get; } = "Base";
    }
}