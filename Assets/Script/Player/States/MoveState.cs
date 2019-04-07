using Script.Player.StateInput;
using UnityEngine;

namespace Script.Player.States
{
    public class MoveState : BasePlayerState
    {
        private float movement;

        public override string Name { get; } = "Move";

        private void Update()
        {        
            movement = StateInput.Input.GetAxisRaw("Horizontal");
            input.Handle();
        }

        private void FixedUpdate()
        {
            player.Move(movement * Time.fixedDeltaTime);
        }
    }
}
