using Script.Player.StateInput;
using UnityEngine;

namespace Script.Player.States
{
    public class MoveState : BasePlayerState
    {
        private float movement;

        public override string Name { get; } = "Move";

        public override bool Enter()
        {
            animator.SetFloat("Speed", 1f);
            effect.Play();
            return base.Enter();
        }

        private void Update()
        {        
            movement = StateInput.Input.GetAxisRaw("Horizontal");
            input.Handle();
        }

        private void FixedUpdate()
        {
            player.Move(movement * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            effect.Stop();
            base.Exit();
        }
    }
}
