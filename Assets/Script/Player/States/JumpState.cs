using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Player.States
{
    public class JumpState : BasePlayerState
    {
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float gravityScale = 2.5f;
        [SerializeField] private float lowScale = 2f;
        [SerializeField] private bool airControl;
        [SerializeField] private int jumpNumber = 2;
        [SerializeField] private GameObject attackHitBox;
        
        private float movement;
        private Vector3 vel;
        private int currentJumpNumber;
        private Transform hitbox;
        
        public override string Name { get; } = "Jump";

        private void Start()
        {
            currentJumpNumber = jumpNumber - 1;
        }

        public void ResetJumps()
        {
            currentJumpNumber = jumpNumber;
            effect.Play();
            sm.ChangeState("Idle");
        }

        public override bool Enter()
        {
            if (currentJumpNumber <= 0) return false;
            if (!IsOnGround()) currentJumpNumber--;
            effect.Play();
            rb.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("isJumping", true);
            vel = Vector3.zero;
            currentJumpNumber--;
            return base.Enter();
        }

        private void Update()
        {
            if (airControl)
                movement = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && currentJumpNumber > 0)
                sm.ChangeState("Jump");
            
            if (Input.GetButtonUp("Jump"))
                rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector2.zero, ref vel, .03f);
            if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
            
            if (rb.velocity.y < 0)
            {
                if (!hitbox) hitbox = Instantiate(attackHitBox, player.transform).transform;
                hitbox.position = player.transform.position;
                rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityScale - 1) * Time.deltaTime;
            } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowScale - 1) * Time.deltaTime;
        }
        
        private void FixedUpdate()
        {
            controller.Move(movement * Time.fixedDeltaTime);
            IsOnGround();
        }
        
        public override void Exit()
        {
            animator.SetBool("isJumping", false);
            if (hitbox) Destroy(hitbox.gameObject);
            effect.Stop();
            base.Exit();
        }
    }
}
