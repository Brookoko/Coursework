using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.MoveControllers
{
    public class FlyController : MonoBehaviour, MoveController {
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        public float horizontalSpeed;
        public float verticalSpeed;
        public float radius;
        
        private bool facingRight = true;
        private Vector2 vec = Vector2.zero;
        private Rigidbody2D rb;
    
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float move)
        {
            float time = Time.time;
            Vector2 vel = new Vector2(Mathf.Cos(time) * horizontalSpeed, Mathf.Sin(time) * verticalSpeed) * radius / 10f;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, vel, ref vec, movementSmoothing);
            if (move < 0 && !facingRight || move > 0 && facingRight)
                Flip();
        }
    
        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}
