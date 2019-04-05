using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D;
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
            movement = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(movement) < 0.01)
                sm.ChangeState("Idle");
            else if (Input.GetButtonDown("Jump"))
                sm.ChangeState("Jump");
            else if (Input.GetButtonDown("Crouch"))
                sm.ChangeState("Crouch");
            else if (Input.GetButtonDown("Dash"))
                sm.ChangeState("Dash");
        }

        private void FixedUpdate()
        {
            controller.Move(movement * Time.fixedDeltaTime);
        }

        public override void Exit()
        {
            effect.Stop();
            base.Exit();
        }
    }
}
