using Script.Player.StateInput;
using UnityEngine;
using Input = Script.Player.StateInput.Input;

namespace Script.Player.States
{
    public class FallState : BasePlayerState
    {
        [SerializeField] private bool airControl;
        [SerializeField] private GameObject attack;
        
        private float movement;
        
        public override string Name { get; } = "Fall";

        public override bool Enter()
        {
            Instantiate(attack, player.transform);
            return base.Enter();
        }

        private void Update()
        {
            if (player.IsOnGround()) sm.ChangeState("Idle");
            movement = Input.GetAxisRaw("Horizontal");
            player.Move(0);
            input.Handle();
        }

        private void FixedUpdate()
        {
            if (airControl) player.Move(movement * Time.fixedDeltaTime);
        }
    }
}