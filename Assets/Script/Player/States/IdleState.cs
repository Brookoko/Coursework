using Script.Player.StateInput;
using UnityEngine;

namespace Script.Player.States
{
    public class IdleState : BasePlayerState
    {
        public override string Name { get; } = "Idle";

        public override bool Enter()
        {
            animator.SetFloat("Speed", 0f);
            return base.Enter();
        }

        private void Update()
        {
            controller.Move(0);
            input.Handle();
        }
    }
}