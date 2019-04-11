﻿using System.Collections;
using System.Collections.Generic;
using Script.Player.StateInput;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Script.Player.States
{
    public class JumpState : BasePlayerState
    {
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float gravityScale = 2.5f;
        [SerializeField] private float lowScale = 2f;
        [SerializeField] private bool airControl;
        
        private float movement;
        
        public override string Name { get; } = "Jump";

        public override bool Enter()
        {
            if (!input.ValidateInput()) return false;
            rb.velocity = Vector2.up * jumpVelocity;
            return base.Enter();
        }

        private void Update()
        {
            if (airControl)
                movement = Input.GetAxisRaw("Horizontal");

            if (rb.velocity.y < 0)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityScale - 1) * Time.deltaTime;
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowScale - 1) * Time.deltaTime;

            input.Handle();
        }
        
        private void FixedUpdate()
        {
            player.Move(movement * Time.fixedDeltaTime);
        }
    }
}
