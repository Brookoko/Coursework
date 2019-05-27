using UnityEngine;

namespace Script.Player.States
{
    public class CrouchState : BasePlayerState
    {
        [Range(0f, 1f)] public float crouchSpeed = 0.4f;
        [SerializeField] private Collider2D colliderToDisable;
        
        private float movement;

        public override string Name { get; } = "Crouch";

        public override bool Enter()
        {
            if (colliderToDisable) colliderToDisable.enabled = false;
            return base.Enter();
        }

        private void Update()
        {
            movement = Input.GetAxisRaw("Horizontal") * crouchSpeed;
            input.Handle();
        }

        private void FixedUpdate()
        {
            player.Move(movement * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            if (colliderToDisable) colliderToDisable.enabled = true;
            base.Exit();
        }
    }
}
