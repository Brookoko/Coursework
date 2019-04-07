using Script.Player.StateInput;
using UnityEngine;

namespace Script.Player.States
{
    public class IdleState : BasePlayerState
    {
        public override string Name { get; } = "Idle";

        private void Update()
        {
            player.Move(0);
            input.Handle();
        }
    }
}